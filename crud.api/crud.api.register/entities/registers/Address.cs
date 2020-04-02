using crud.api.core.attributes;
using crud.api.core.entities;
using System;

namespace crud.api.register.entities.registers
{
    public class Address : BaseEntity
    {
        [IsRequiredField]
        public string PostalCode { get; set; }
        [IsRequiredField]
        public City City { get; set; }
        [IsRequiredField]
        public string StreetName { get; set; }
        [IsRequiredField]
        public string Neighborhood { get; set; }
        [IsRequiredField]
        public string Number { get; set; }
        public string Complement { get; set; }
        [IsRequiredField]
        public string AddressType { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as Address;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (this.PostalCode != null && this.PostalCode.Equals(unboxed.PostalCode))
            {
                return true;
            }

            bool? result = false;

            result = this.City?.Equals(unboxed.City) &
                this.Number?.Equals(unboxed.Number) &
                this.Neighborhood?.Equals(unboxed.Neighborhood) &
                this.StreetName?.Equals(unboxed.StreetName);

            return Convert.ToBoolean(result);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
