using crud.api.core.entities;
using crud.api.register.entities.registers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.validations.register
{
    public class PersonValidator<TUser> : BaseValidator<Person<TUser>> where TUser : class, IEntity
    {
        public PersonValidator(): base()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .Length(10, 110)
                .WithMessage(string.Format(invalidValue, "'Name'"));
            RuleFor(x => x.Birthday)
                .GreaterThan(DateTime.UtcNow.AddYears(-1))
                .NotNull()
                .WithMessage($"You need be one year old or more.");
            RuleFor(x => x.Gender)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, "'Gender'"));
            RuleFor(x => x.MaritalStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, "'MaritalStatus'"));
            RuleForEach(i => i.Documents)
                .SetValidator(new DocumentValaidator());
            RuleForEach(i => i.Addresses)
                .SetValidator(new AddressValaidator());
            RuleForEach(i => i.Contacts)
                .SetValidator(new ContactValaidator());
            RuleFor(x => x.User)
                .SetValidator(new UserValidator<TUser>());

        }
    }
}
