using crud.api.core.entities;
using crud.api.core.interfaces;
using data.provider.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace crud.api.core.repositories
{
    public class BaseRepository<T, TEntity> : IBaseRepository<T>, IDisposable where TEntity : IEntity where T : class
    {
        protected readonly IDataSet<T> _dataset = null;
        //protected readonly IDataProvider _provider = null;

        public BaseRepository(IDataProvider provider)
        {
            //this._provider = provider;
            this._dataset = provider.GetDataSet<T>();
        }

        public IEnumerable<IHandleMesage> AppenData(T entity)
        {
            var tentity = (TEntity)Convert.ChangeType(entity, typeof(TEntity));
            var validation = tentity.Validate();

            if (validation != null && validation.Any() && validation.Count() > 0)
            {
                return validation;
            }

            this._dataset.Append(new List<T>() { entity });

            return new List<IHandleMesage>() { new HandleMessageAbs("AppendData", "Inserted record in provider.") };            
        }

        public IEnumerable<IHandleMesage> DeleteData(T entity)
        {
            var tentity = (TEntity)Convert.ChangeType(entity, typeof(TEntity));
            var check = this._dataset.DeleteRecords(e => (e as IEntity).Id == tentity.Id);

            if (check <= 0)
            {
                return new List<IHandleMesage>() { new HandleMessageAbs("RecordNotFoundException", "Provider not found record.") };
            }

            return new List<IHandleMesage>() { new HandleMessageAbs("DeltedRecord", "Record was removed from data provider.") }; ;
        }

        public void Dispose()
        {
            this._dataset.Dispose();
        }

        public IEnumerable<T> GetData(Expression<Func<T, bool>> func, int top = 0)
        {
            var result = this._dataset.GetEntities(func, top);

            if (result is null)
            {
                return new List<T>();
            }
            else
            {
                return result.ToList();
            }
        }

        public IEnumerable<IHandleMesage> UpdateData(T entity, Expression<Func<T, bool>> predicate)
        {
            var tentity = (TEntity)Convert.ChangeType(entity, typeof(TEntity));
            var validation = tentity.Validate();

            if (validation != null && validation.Any() && validation.Count() > 0)
            {
                return validation;
            }

            var count = this._dataset.UpdateRecords(predicate, entity);

            if (count <= 0)
            {
                return new List<IHandleMesage>() { new HandleMessageAbs("RecordNotFoundException", "Record not found in data provider to change.") };
            }

            return new List<IHandleMesage>() { new HandleMessageAbs("RecordChanged", "The record was changed.") };
        }
    }
}
