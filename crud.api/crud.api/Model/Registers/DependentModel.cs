using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.Model.Registers
{
    public class DependentModel: PersonModel
    {
        public Guid ForeignId { get; set; }
    }
}
