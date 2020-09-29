using crud.api.core.repositories;
using crud.api.GraphQL.Types;
using crud.api.register.entities.registers;
using graph.simplify.core.queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.GraphQL.Queries.InternalQueries
{
    public class PersonQuery : AppQuery<Person<PersonAddress>, PersonType>
    {
        public PersonQuery(IRepository<Person<PersonAddress>> repository) : base(repository)
        {
        }
    }
}
