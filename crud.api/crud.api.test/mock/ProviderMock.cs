using data.provider.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.test.mock
{
    internal class ProviderMock : IDataProvider
    {
        public void Dispose()
        {
            
        }

        public IDataSet<TEntity> GetDataSet<TEntity>() where TEntity : class
        {
            return (IDataSet<TEntity>)(new DataSetMock(1));
        }
    }
}
