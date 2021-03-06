﻿using city.core.entities;
using crud.api.core.attributes;
using crud.api.core.entities;
using crud.api.core.enums;
using crud.api.core.interfaces;
using crud.api.register.entities.registers.relational;
using crud.api.register.validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace crud.api.register.entities.registers
{
    public class Person<TUser> : BaseEntity where TUser : class
    {
        [IsRequiredField]
        public Guid AccountId { get; set; }
        [IsRequiredField]
        public string Name { get; set; }
        public string NickName { get; set; }
        [IsRequiredField]
        public DateTime Birthday { get; set; }
        [IsRequiredField]
        public int Gender { get; set; }
        [IsRequiredField]
        public int MaritalStatus { get; set; }
        [IsRequiredField]
        public bool SpecialNeeds { get; set; }
        public string Profession { get; set; }
        public string PictureUrl { get; set; }
        public TUser User { get; set; }
        [IsRequiredField]
        public virtual City BirthCity { get; set; }
        public virtual IEnumerable<PersonDocument> Documents { get; set; }
        public virtual IEnumerable<PersonContact> Contacts { get; set; }
        public virtual IEnumerable<PersonAddress> Addresses { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as Person<TUser>;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            bool? result = false;

            if (unboxed.Documents != null & this.Documents != null)
            {
                this.Documents?.ToList().ForEach(item => {
                    if (unboxed.Documents.Any(i => i.Equals(item)))
                    {
                        result = true;
                    }
                });

                if (Convert.ToBoolean(result))
                {
                    return true;
                }
            }            

            result = this.Name?.Equals(unboxed.Name) &
                this.Birthday.Equals(unboxed.Birthday) &
                //this.BirthCity?.Equals(unboxed.BirthCity) &
                this.Gender.Equals(unboxed.Gender);

            return Convert.ToBoolean(result);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerable<IHandleMessage> Validate(BaseValidator<Person<TUser>> validator)
        {
            var validations = validator.Validate(this);
            
            if (validations.IsValid)
            {
                return this.Validate();
            }

            var result = new List<IHandleMessage>(validations.Errors.Count);
            foreach (var item in validations.Errors)
            {
                result.Add(new HandleMessageAbs(item.PropertyName, item.ErrorMessage, HandlesCode.InvalidField));
            }

            return result;
        }
    }
}
