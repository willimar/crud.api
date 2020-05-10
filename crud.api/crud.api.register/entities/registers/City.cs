using crud.api.core.attributes;
using crud.api.core.entities;
using System;

namespace crud.api.register.entities.registers
{
    public class City : BaseEntity
    {
        [IsRequiredField]
        public string Name { get; set; }
        public int CityCode { get; set; }
        [IsRequiredField]
        public State State { get; set; }
        public long Population { get; set; }
        public decimal Area { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as City;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (this.Id.Equals(unboxed.Id))
            {
                return true;
            }

            if (Convert.ToBoolean(unboxed.Name?.Equals(this.Name)))
            {
                return true;
            }

            if ((unboxed.CityCode.Equals(this.CityCode) & this.CityCode != 0))
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
