using crud.api.register.entities.registers;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace crud.api.register.validations.register
{
    public class AddressValaidator : BaseValidator<PersonAddress>
    {
        public AddressValaidator()
        {
            RuleFor(x => x.CityId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'City'"));
            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'City'"));
            RuleFor(x => x.Country)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'Country'"));
            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .Length(1, 10)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'Number'"));
            RuleFor(x => x.PostalCode)
                .NotNull()
                .NotEmpty()
                .Length(8, 15)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'PostalCode'"));
            RuleFor(x => x.State)
                .NotNull()
                .NotEmpty()
                .Length(2, 10)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'State'"));
            RuleFor(x => x.StreetName)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage(string.Format(invalidValue, "PersonAddress", "'StreetName'"));
        }
    }
}