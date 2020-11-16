using crud.api.core.entities;
using FluentValidation;
using FluentValidation.Validators;

namespace crud.api.register.validations.register
{
    public class UserValidator<TUser> : BaseValidator<TUser> where TUser : class, IEntity
    {
        public UserValidator()
        {
            
        }
    }
}