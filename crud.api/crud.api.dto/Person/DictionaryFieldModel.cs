using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.dto.Person
{
    public class DictionaryFieldModel<TEnum> where TEnum : Enum
    {
        public Guid Id { get; set; }
        public Guid ForeignId { get; set; }
        public string Value { get; set; }
        public TEnum Type { get; set; }
    }
}
