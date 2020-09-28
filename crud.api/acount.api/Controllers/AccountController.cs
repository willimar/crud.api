using city.core.entities;
using crud.api.core;
using crud.api.core.enums;
using crud.api.core.interfaces;
using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.dto.Person;
using crud.api.register.entities.registers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace acount.api.Controllers
{
    [EnableCors(Program.AllowSpecificOrigins)]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly MapperProfile<PersonModel, Person> _userProfile;
        private readonly IService<Person> _personService;
        private readonly IRepository<City> _cityRepository;

        public AccountController(IService<Person> personService, MapperProfile<PersonModel, Person> userProfile, IRepository<City> city)
        {
            this._userProfile = userProfile;
            this._personService = personService;
            this._cityRepository = city;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Append(PersonModel value)
        {
            List<IHandleMessage> handleMessage = new List<IHandleMessage>();

            try
            {
                var entity = this._personService.GetData(e =>
                    e.IsRoot &&
                    (e.User.UserName.Equals(value.UserInfo.UserName) ||
                    e.User.UserEmail.Equals(value.UserInfo.UserEmail))
                ).FirstOrDefault();

                // Only one account by email or username
                if (entity != null)
                {
                    handleMessage.Add(new HandleMessage("ThereIsUser", $"Account with this e-mail or user name was found.", HandlesCode.ManyRecordsFound));
                    return StatusCode((int)HttpStatusCode.BadRequest, handleMessage);
                }

                entity = this._userProfile.Map(value);

                entity.Id = Guid.NewGuid();
                entity.IsRoot = true;
                entity.RootId = entity.Id;

                var validate = entity.Validate();

                if (validate.Any())
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, validate);
                }

                handleMessage.AddRange(this._personService.SaveData(entity));

                return StatusCode((int)HttpStatusCode.OK, handleMessage);
            }
            catch (Exception e)
            {
                handleMessage.Add(new HandleMessage(e));
                return StatusCode((int)HttpStatusCode.InternalServerError, handleMessage);
            }
        }
    }
}
