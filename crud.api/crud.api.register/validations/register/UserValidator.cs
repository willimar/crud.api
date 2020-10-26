using crud.api.core.entities;
using FluentValidation;
using FluentValidation.Validators;

namespace crud.api.register.validations.register
{
    public class UserValidator<TUser> : BaseValidator<TUser> where TUser : class, IEntity
    {
        public UserValidator()
        {
            RuleFor(x => x.GetType().GetProperty("UserName"))
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, this.GetType().Name, "'UserName'"));
            RuleFor(x => x.GetType().GetProperty("Login"))
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, this.GetType().Name, "'Login'"));
            RuleFor(x => x.GetType().GetProperty("Email"))
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(invalidValue, this.GetType().Name, "'Email'"));
        }
    }
}