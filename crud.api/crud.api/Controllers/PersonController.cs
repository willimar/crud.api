using crud.api.core.enums;
using crud.api.core.exceptions;
using crud.api.core.fieldType;
using crud.api.core.interfaces;
using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.Enums;
using crud.api.Miscellaneous;
using crud.api.Model.Registers;
using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        private readonly MapperProfile<Person, Person> _personProfile;
        private readonly IService<Person> _personService;
        private readonly IService<PersonDocument> _documentService;
        private readonly IRepository<City> _cityRepository;

        public PersonController(MapperProfile<PersonModel, Person> personModelProfile, MapperProfile<Person, Person> personProfile,
            IService<Person> personService, IService<PersonDocument> documentService, IRepository<City> city)
        {
            this._personModelPorfile = personModelProfile;
            this._personProfile = personProfile;
            this._personService = personService;
            this._documentService = documentService;
            this._cityRepository = city;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Person(PersonModel value)
        {
            Person person = null;

            if (value.Id != Guid.Empty)
            {
                var entity = this._personService.GetData(e => e.Id.Equals(value.Id)).FirstOrDefault();

                if (entity == null)
                {
                    person = this._personModelPorfile.Map(value);
                    person.BirthCity = this._cityRepository.GetData(c => c.Id.Equals(value.BirthCity)).FirstOrDefault();
                }
                else
                {
                    person = this._personModelPorfile.Map(value, entity);
                    person.BirthCity = this._cityRepository.GetData(c => c.Id.Equals(value.BirthCity)).FirstOrDefault();
                }
            }

            if (person == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            var handleMessages = person.Validate();

            if (!handleMessages.Any())
            {
                handleMessages = this._personService.SaveData(person);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Document(DictionaryFieldModel<DocumentType> value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            PersonDocument document = null;

            if (!entity.Documents.Any(d => d.Id.Equals(value.Id)))
            {
                document = new PersonDocument() { 
                    Id = value.Id == Guid.Empty ? Guid.NewGuid() : value.Id,
                    LastChangeDate = DateTime.UtcNow,
                    RegisterDate = DateTime.UtcNow,
                    Status = RecordStatus.Active,
                    Type = value.Type.ToString(),
                    Value = value.Value,
                    Person = entity
                };
            }
            else
            {
                document = entity.Documents.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                document.LastChangeDate = DateTime.UtcNow;
                document.Status = RecordStatus.Active;
                document.Value = value.Value;
                document.Type = value.Type.ToString();
            }

            var handleMessages = new List<IHandleMessage>();

            handleMessages.AddRange(document.Validate());

            if (!handleMessages.Any())
            {
                this._documentService.SaveData(document);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Contacts(DictionaryFieldModel<ContactType> value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Dependents(DependentModel value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Address(AddressModel value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Message(DictionaryFieldModel<MessageType> value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            throw new NotImplementedException();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<IHandleMessage>> Type(DictionaryFieldModel<PersonsType> value)
        {
            var entity = this._personService.GetData(e => e.Id.Equals(value.ForeignId)).FirstOrDefault();

            if (entity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, HandleMessageAbs.Factory(HandlesCode.ValueNotFound, "Record not found.", nameof(ValueNotFoundException)));
            }

            throw new NotImplementedException();
        }
    }
}