using crud.api.core.repositories;
using data.provider.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.test.mock
{
    internal class RepositoryMock : BaseRepository<TesteEntity>
    {
        public RepositoryMock(IDataProvider provider) : base(provider)
        {
        }
    }
}
