using city.core.entities;
using crud.api.core.fieldType;
using GraphQL.Types;

namespace crud.api.GraphQL.Types
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType()
        {
            Field(x => x.Id, type: typeof(GuidGraphType)).Description("Property Id is Guid type and unique in database.");
            Field(f => f.HashId).Description("Is hash from {city.Ibge7Code}{city.IbgeCode}{city.Name}");
            Field(f => f.Ibge7Code);
            Field(f => f.IbgeCode);
            Field(f => f.IsCapital);
            Field(f => f.LastChangeDate, type: typeof(DateTimeGraphType));
            Field(f => f.Name);
            Field(f => f.Population);
            Field(f => f.Region);
            Field(f => f.RegisterDate, type: typeof(DateTimeGraphType));
            Field(f => f.Size);
            Field(f => f.Uf);
            Field(f => f.State, type: typeof(StateType));
            Field(f => f.Status, type: typeof(EnumerationGraphType<RecordStatus>));
        }
    }
}