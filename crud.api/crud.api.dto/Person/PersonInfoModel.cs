using System;

namespace crud.api.dto.Person
{

    public class PersonInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthState { get; set; }
        public Guid BirthCity { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public bool SpecialNeeds { get; set; }
        public string Profession { get; set; }
    }
}
