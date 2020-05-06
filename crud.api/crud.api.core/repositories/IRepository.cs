using crud.api.core.entities;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace crud.api.core.repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<IHandleMessage> UpdateData(TEntity entity, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<IHandleMessage> AppenData(TEntity entity);
        IEnumerable<IHandleMessage> DeleteData(TEntity entity);
        IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func, int top = 0, int page = 0);
        void Dispose();
    }
}
