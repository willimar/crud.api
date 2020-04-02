﻿using crud.api.core.attributes;
using crud.api.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace crud.api.register.entities.registers
{
    public class Person : BaseEntity
    {
        [IsRequiredField]
        public string Name { get; set; }
        public string NickName { get; set; }
        [IsRequiredField]
        public IEnumerable<DictionaryField> Documents { get; set; }
        public IEnumerable<DictionaryField> Contacts { get; set; }
        public IEnumerable<Person> Dependents { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public DateTime Birthday { get; set; }
        public City BirthCity { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public bool SpecialNeeds { get; set; }
        public IEnumerable<DictionaryMesage> Mesages { get; set; }
        public string Profession { get; set; }
        public string PictureUrl { get; set; }
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as Person;

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
                this.BirthCity?.Equals(unboxed.BirthCity) &
                this.Gender?.Equals(unboxed.Gender);

            return Convert.ToBoolean(result);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}