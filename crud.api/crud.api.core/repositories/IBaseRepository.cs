using crud.api.core.entities;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace crud.api.core.repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<IHandleMesage> UpdateData(TEntity entity, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<IHandleMesage> AppenData(TEntity entity);
        IEnumerable<IHandleMesage> DeleteData(TEntity entity);
        IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func, int top = 0);
        void Dispose();
    }
}
