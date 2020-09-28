using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.dto.Person
{
    public class UserModel: PersonInfoModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
    }
}
