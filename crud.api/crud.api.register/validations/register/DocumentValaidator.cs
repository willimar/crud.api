using crud.api.register.entities.registers.relational;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.validations.register
{
    public class DocumentValaidator : BaseValidator<PersonDocument>
    {
        public DocumentValaidator()
        {
            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, "PersonDocument", "'Type'"));
            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .Length(5, 50)
                .WithMessage(string.Format(invalidValue, "PersonDocument", "'Value'"));
        }
    }
}
