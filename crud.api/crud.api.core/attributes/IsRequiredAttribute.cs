using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsRequiredFieldAttribute : Attribute
    {
        public bool Required { get; }

        public IsRequiredFieldAttribute(bool required = true)
        {
            this.Required = required;
        }
    }
}
