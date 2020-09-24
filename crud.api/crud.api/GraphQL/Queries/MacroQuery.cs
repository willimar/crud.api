using crud.api.GraphQL.Queries.InternalQueries;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.GraphQL.Queries
{
    public class MacroQuery : ObjectGraphType
    {
        public MacroQuery(PersonQuery person)
        {
            person.Fields.ToList().ForEach(item => this.AddField(item));
        }
    }
}
