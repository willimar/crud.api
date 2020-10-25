using crud.api.core.entities;
using crud.api.core.fieldType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.validations
{
    public class BaseValidator<TEntity>: AbstractValidator<TEntity> where TEntity : IEntity
    {
        protected const string invalidValue = "Invalid value to field name {0}.";
        
        public BaseValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(string.Format(invalidValue, "'Id'"));
            RuleFor(x => x.LastChangeDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .GreaterThan(DateTime.UtcNow.AddDays(-1))
                .WithErrorCode("401")
                .WithMessage(string.Format(invalidValue, "'LastChangeDate'"));
            RuleFor(x => x.RegisterDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(string.Format(invalidValue, "'RegisterDate'"));
            RuleFor(x => x.Status)
                .NotNull()
                .NotEqual(RecordStatus.Default)
                .WithMessage(string.Format(invalidValue, "'Status'"));
        }
    }
}
