using data.provider.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace crud.api.test.mock
{
    internal class DataSetMock : IDataSet<TesteEntity>
    {
        private readonly long _return;
        private List<TesteEntity> _dadaList = new List<TesteEntity>() { new TesteEntity() { Id = Guid.NewGuid() } };

        public DataSetMock(long returns) {
            this._return = returns;
        }
        public void Append(IEnumerable<TesteEntity> entity)
        {
            entity.ToList().ForEach(item => { _dadaList.Add(item); });
        }

        public long Count(Expression<Func<TesteEntity, bool>> predicate)
        {
            return _dadaList.Count(predicate.Compile());
        }

        public long DeleteRecords(Expression<Func<TesteEntity, bool>> predicate)
        {
            var itens = _dadaList.Where(predicate.Compile());
            var result = itens.Count();

            itens.ToList().ForEach(i => _dadaList.Remove(i));
            return result;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<TesteEntity> GetEntities(Expression<Func<TesteEntity, bool>> predicate, int limit = 0)
        {
            if (limit > 0)
            {
                return _dadaList.Where(predicate.Compile()).Take(limit);
            }

            return _dadaList.Where(predicate.Compile());
        }

        public long UpdateRecords(Expression<Func<TesteEntity, bool>> predicate, TesteEntity entity)
        {
            var result = this.DeleteRecords(predicate);
            this.Append(new List<TesteEntity>() { entity });
            return result;
        }
    }
}
