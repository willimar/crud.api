using crud.api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.Model.Registers
{
    public class AddressModel
    {
        public string PostalCode { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public AddressType AddressType { get; set; }
    }
}
