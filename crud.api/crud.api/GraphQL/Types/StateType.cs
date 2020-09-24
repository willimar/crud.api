using city.core.entities;
using GraphQL.Types;

namespace crud.api.GraphQL.Types
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType()
        {
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.IbgeCode);
            Field(x => x.Initials);
            Field(x => x.Name);
            Field(x => x.NumberCities);
            Field(x => x.Region);
            Field(x => x.Country, type: typeof(CountryType));
        }
    }
}