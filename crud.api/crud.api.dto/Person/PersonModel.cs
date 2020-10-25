using crud.api.dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.dto.Person
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public PersonInfoModel PersonInfo { get; set; }
        public UserModel UserInfo { get; set; }
        public List<DictionaryFieldModel<ContactType>> PersonalContacts { get; set; }
        public List<AddressModel> Addresses { get; set; }
        public List<DictionaryFieldModel<DocumentType>> Documents { get; set; }
    }
}
