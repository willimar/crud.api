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
        protected const string invalidValue = "The entity {0} has a invalid value to field {1}.";
        
        public BaseValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(string.Format(invalidValue, typeof(TEntity).Name.Replace("`1", string.Empty), "'Id'"));
            RuleFor(x => x.LastChangeDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(5))
                .GreaterThan(DateTime.UtcNow.AddDays(-1))
                .WithErrorCode("401")
                .WithMessage(string.Format(invalidValue, typeof(TEntity).Name.Replace("`1", string.Empty), "'LastChangeDate'"));
            RuleFor(x => x.RegisterDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(5))
                .WithMessage(string.Format(invalidValue, typeof(TEntity).Name.Replace("`1", string.Empty), "'RegisterDate'"));
            RuleFor(x => x.Status)
                .NotNull()
                .NotEqual(RecordStatus.Default)
                .WithMessage(string.Format(invalidValue, typeof(TEntity).Name.Replace("`1", string.Empty), "'Status'"));
        }
    }
}
