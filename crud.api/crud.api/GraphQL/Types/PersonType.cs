using crud.api.core.fieldType;
using crud.api.register.entities.registers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(f => f.Id, type: typeof(GuidGraphType));
            Field(f => f.RegisterDate, type: typeof(DateTimeGraphType));
            Field(f => f.LastChangeDate, type: typeof(DateTimeGraphType));
            Field(f => f.Status, type: typeof(EnumerationGraphType<RecordStatus>));
            Field(f => f.Name);
            Field(f => f.NickName);
            Field(f => f.Birthday, type: typeof(DateGraphType));
            Field(f => f.Gender);
            Field(f => f.MaritalStatus);
            Field(f => f.SpecialNeeds);
            Field(f => f.Profession);
            Field(f => f.PictureUrl);
            Field(f => f.BirthCity, type: typeof(CityType));

            Field(f => f.Documents, type: typeof(ListGraphType<DictionaryFieldType>));
            Field(f => f.Contacts, type: typeof(ListGraphType<DictionaryFieldType>));
            Field(f => f.Addresses, type: typeof(ListGraphType<DictionaryFieldType>));
        }
    }
}
