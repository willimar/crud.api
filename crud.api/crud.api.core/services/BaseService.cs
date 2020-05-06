using crud.api.core.entities;
using crud.api.core.interfaces;
using crud.api.core.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace crud.api.core.services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<IHandleMessage> AppenData(TEntity entity)
        {
            return this._repository.AppenData(entity);
        }

        public IEnumerable<IHandleMessage> DeleteData(TEntity entity)
        {
            return this._repository.DeleteData(entity);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func, int top = 0, int page = 0)
        {
            return this._repository.GetData(func, top, page);
        }

        public IEnumerable<IHandleMessage> UpdateData(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            return this._repository.UpdateData(entity, predicate);
        }
    }
}
