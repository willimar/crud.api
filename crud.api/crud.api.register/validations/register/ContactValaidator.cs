using crud.api.register.entities.registers.relational;
using FluentValidation;
using FluentValidation.Validators;

namespace crud.api.register.validations.register
{
    public class ContactValaidator : BaseValidator<PersonContact>
    {
        public ContactValaidator()
        {
            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, "PersonContact", "'Type'"));
            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .Length(5, 50)
                .WithMessage(string.Format(invalidValue, "PersonContact", "'Value'"));
        }
    }
}