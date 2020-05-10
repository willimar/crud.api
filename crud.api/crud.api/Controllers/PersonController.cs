using crud.api.core.interfaces;
using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.Enums;
using crud.api.Model.Registers;
using crud.api.register.entities.registers;
using crud.api.register.repositories.registers;
using crud.api.register.services.registers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace crud.api.Controllers
{
    [EnableCors(Program.AllowSpecificOrigins)]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MapperProfile<PersonModel, Person> _personModelPorfile;
        private readonly IService<Person> _service;
        private readonly IMapperEntity _mapper;
        private readonly IRepository<City> _cityRepository;
        private readonly MapperProfile<Person, Person> _personProfile;

        public PersonController(MapperProfile<PersonModel, Person> personModelProfile, MapperProfile<Person, Person> personProfile,
            IService<Person> service, IRepository<City> city)
        {
            this._personModelPorfile = personModelProfile;
            this._service = service;
            this._cityRepository = city;
            this._personProfile = personProfile;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Person(PersonModel value)
        {
            Person person = null;

            if (value.Id != Guid.Empty)
            {
                var entity = this._service.GetData(e => e.Id.Equals(value.Id)).FirstOrDefault();

                if (entity == null)
                {
                    person = this._personModelPorfile.Map(value);
                    person.BirthCity = this._cityRepository.GetData(c => c.Id.Equals(value.BirthCity)).FirstOrDefault();
                }
                else
                {
                    person = this._personProfile.Map(person);
                }
            }

            var handleMessages = person.Validate();

            if (!handleMessages.Any())
            {
                handleMessages = this._service.SaveData(person);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Document(DictionaryFieldModel<DocumentType> value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Contacts(DictionaryFieldModel<ContactType> value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Dependents(DependentModel value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Address(AddressModel value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Message(DictionaryFieldModel<MessageType> value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Type(DictionaryFieldModel<PersonType> value)
        {
            throw new NotImplementedException();
        }
    }
}