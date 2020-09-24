using crud.api.core.fieldType;
using crud.api.register.entities.registers;
using GraphQL.Types;

namespace crud.api.GraphQL.Types
{
    internal class DictionaryFieldType: ObjectGraphType<DictionaryField>
    {
        public DictionaryFieldType()
        {
            Field(f => f.Id, type: typeof(GuidGraphType));
            Field(f => f.RegisterDate, type: typeof(DateTimeGraphType));
            Field(f => f.LastChangeDate, type: typeof(DateTimeGraphType));
            Field(f => f.Status, type: typeof(EnumerationGraphType<RecordStatus>));
            Field(f => f.Type, type: typeof(StringGraphType));
            Field(f => f.Value);
        }
    }
}