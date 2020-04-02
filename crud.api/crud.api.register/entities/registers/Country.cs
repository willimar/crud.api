using crud.api.core.attributes;
using crud.api.core.entities;
using System;

namespace crud.api.register.entities.registers
{
    public class Country : BaseEntity
    {
        [IsRequiredField]
        public string Name { get; set; }
        [IsRequiredField]
        public string Acronym { get; set; }
        public int CountryCode { get; set; }
        public string IsoCode { get; set; }
        public long Population { get; set; }
        public decimal Area { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as Country;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (Convert.ToBoolean(unboxed.Name?.Equals(this.Name)))
            {
                return true;
            }

            if ((unboxed.CountryCode.Equals(this.CountryCode) & this.CountryCode != 0))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
