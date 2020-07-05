using city.core.entities;
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
using graph.simplify.consumer;
using graph.simplify.consumer.enums;
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
        private readonly IService<PersonContact> _contactService;
        private readonly IService<PersonDocument> _documentService;
        private readonly IRepository<City> _cityRepository;
        private readonly IService<PersonAddress> _addressService;
        private readonly IService<PersonMessage> _messageService;
        private readonly IService<PersonType> _typeService;

        public PersonController(MapperProfile<PersonModel, Person> personModelProfile, MapperProfile<Person, Person> personProfile, IRepository<City> city,
            IService<Person> personService, 
            IService<PersonDocument> documentService,
            IService<PersonContact> contactService,
            IService<PersonAddress> addressService,
            IService<PersonMessage> messageService,
            IService<PersonType> typeService)
        {
            this._personModelPorfile = personModelProfile;
            this._personProfile = personProfile;
            this._personService = personService;
            this._contactService = contactService;
            this._documentService = documentService;
            this._cityRepository = city;
            this._addressService = addressService;
            this._messageService = messageService;
            this._typeService = typeService;
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

            PersonContact contact = null;

            if (!entity.Contacts.Any(d => d.Id.Equals(value.Id)))
            {
                contact = new PersonContact()
                {
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
                contact = entity.Contacts.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                contact.LastChangeDate = DateTime.UtcNow;
                contact.Status = RecordStatus.Active;
                contact.Value = value.Value;
                contact.Type = value.Type.ToString();
            }

            var handleMessages = new List<IHandleMessage>();

            handleMessages.AddRange(contact.Validate());

            if (!handleMessages.Any())
            {
                this._contactService.SaveData(contact);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
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

            Person person = null;

            if (!entity.Dependents.Any(d => d.Id.Equals(value.Id)))
            {
                person = this._personModelPorfile.Map(value);
            }
            else
            {
                person = entity.Dependents.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                person = this._personModelPorfile.Map(value, person);
                person.LastChangeDate = DateTime.UtcNow;
                person.Status = RecordStatus.Active;                
            }

            var handleMessages = new List<IHandleMessage>();

            handleMessages.AddRange(person.Validate());

            if (!handleMessages.Any())
            {
                this._personService.SaveData(person);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
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

            PersonAddress address = null;

            var postalCodeCheck = new GraphClient();
            var body = postalCodeCheck.AppendBody("Address");
            body.AppendArgument("postalCode")
                .AppendCheck(OperationType.EqualTo, Statement.And, value.PostalCode);

            body.ResultFields.Add("postalCode");
            body.ResultFields.Add("district");
            body.ResultFields.Add("fullStreetName");
            body.ResultFields.Add("city{name, state{initials, country{name}}}");

            postalCodeCheck.Resolve(Program.PostalCodeApi);

            dynamic postalCode = null;
            var handleMessages = new List<IHandleMessage>();

            if (postalCodeCheck.Result.data.address.Count != 0)
            {
                postalCode = postalCodeCheck.Result.data.address[0];
            }
            else
            {
                handleMessages.Add(HandleMessageAbs.Factory(HandlesCode.ValueNotFound, $"Postal code {value.PostalCode} wasn't found.", "PostalCodeNotFoundException"));
            }
            
            if (!entity.Addresses.Any(d => d.Id.Equals(value.Id)))
            {
                address = new PersonAddress()
                {
                    Id = value.Id == Guid.Empty ? Guid.NewGuid() : value.Id,
                    LastChangeDate = DateTime.UtcNow,
                    RegisterDate = DateTime.UtcNow,
                    Status = RecordStatus.Active,
                    AddressType = value.AddressType.ToString(),
                    PostalCode = value.PostalCode,
                    City = Convert.ToString(postalCode?.city?.name),
                    StreetName = Convert.ToString(postalCode?.fullStreetName),
                    Country = Convert.ToString(postalCode?.city.state.country.name),
                    Neighborhood = Convert.ToString(postalCode?.district),
                    State = Convert.ToString(postalCode?.city.state.initials),
                    Number = value.Number,
                    Complement = value.Complement,
                    Person = entity
                };
            }
            else
            {
                address = entity.Addresses.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                address.LastChangeDate = DateTime.UtcNow;
                address.Status = RecordStatus.Active;

                address.AddressType = value.AddressType.ToString();
                address.PostalCode = value.PostalCode;
                address.City = Convert.ToString(postalCode?.city.name);
                address.StreetName = Convert.ToString(postalCode?.fullStreetName);
                address.Country = Convert.ToString(postalCode?.city.state.country.name);
                address.Neighborhood = Convert.ToString(postalCode?.district);
                address.State = Convert.ToString(postalCode?.city.state.initials);
                address.Number = value.Number;
                address.Complement = value.Complement;
                address.Person = entity;
            }

            handleMessages.AddRange(address.Validate());

            if (!handleMessages.Any())
            {
                this._addressService.SaveData(address);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
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

            PersonMessage message = null;

            if (!entity.Messages.Any(d => d.Id.Equals(value.Id)))
            {
                message = new PersonMessage()
                {
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
                message = entity.Messages.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                message.LastChangeDate = DateTime.UtcNow;
                message.Status = RecordStatus.Active;
                message.Value = value.Value;
                message.Type = value.Type.ToString();
            }

            var handleMessages = new List<IHandleMessage>();

            handleMessages.AddRange(message.Validate());

            if (!handleMessages.Any())
            {
                this._messageService.SaveData(message);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
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

            PersonType message = null;

            if (!entity.Types.Any(d => d.Id.Equals(value.Id)))
            {
                message = new PersonType()
                {
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
                message = entity.Types.Where(d => d.Id.Equals(value.Id)).FirstOrDefault();

                message.LastChangeDate = DateTime.UtcNow;
                message.Status = RecordStatus.Active;
                message.Value = value.Value;
                message.Type = value.Type.ToString();
            }

            var handleMessages = new List<IHandleMessage>();

            handleMessages.AddRange(message.Validate());

            if (!handleMessages.Any())
            {
                this._typeService.SaveData(message);
            }

            return StatusCode((int)HttpStatusCode.OK, handleMessages);
        }

    }
}