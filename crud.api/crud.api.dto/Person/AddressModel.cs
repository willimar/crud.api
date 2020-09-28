using crud.api.dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.dto.Person
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public Guid ForeignId { get; set; }
        public string PostalCode { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public AddressType AddressType { get; set; }
    }
}
