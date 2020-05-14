using crud.api.core.attributes;
using crud.api.core.entities;
using System;

namespace crud.api.register.entities.registers
{
    public class State : BaseEntity
    {
        [IsRequiredField]
        public string Name { get; set; }
        [IsRequiredField]
        public string Acronym { get; set; }
        public int StateCode { get; set; }
        public long Population { get; set; }
        public decimal Area { get; set; }
        [IsRequiredField]
        public virtual Country Country { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as State;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (Convert.ToBoolean(unboxed.Name?.Equals(this.Name)))
            {
                return true;
            }

            if ((unboxed.StateCode.Equals(this.StateCode) & this.StateCode != 0))
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
