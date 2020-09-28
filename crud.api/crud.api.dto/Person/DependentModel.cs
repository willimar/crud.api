using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.dto.Person
{
    public class DependentModel: PersonInfoModel
    {
        public Guid ForeignId { get; set; }
    }
}
