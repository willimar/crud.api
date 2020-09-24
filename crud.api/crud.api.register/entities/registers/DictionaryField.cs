using crud.api.core.attributes;
using crud.api.core.entities;
using System;

namespace crud.api.register.entities.registers
{
    public class DictionaryField : BaseEntity
    {
        [IsRequiredField]
        public string Value { get; set; }
        [IsRequiredField]
        public object Type { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as DictionaryField;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (Convert.ToBoolean(unboxed.Value?.Equals(this.Value)) &&
                Convert.ToBoolean(unboxed.Type?.Equals(this.Type)))
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
