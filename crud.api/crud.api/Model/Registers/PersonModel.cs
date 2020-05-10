using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace crud.api.Model.Registers
{
    
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDay { get; set; }
        public Guid BirthCity { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public bool SpecialNeeds { get; set; }
        public string Profession { get; set; }
    }
}
