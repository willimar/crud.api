using crud.api.core.entities;
using crud.api.core.enums;
using crud.api.core.interfaces;
using data.provider.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace crud.api.core.repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected readonly IDataSet<TEntity> _dataset = null;
        
        public BaseRepository(IDataProvider provider)
        {
            //this._provider = provider;
            this._dataset = provider.GetDataSet<TEntity>();
        }

        private List<IHandleMessage> CheckEntityType(TEntity entity)
        {
            if (entity.GetType().IsAssignableFrom(typeof(IEntity)))
            {
                return new List<IHandleMessage>() { new HandleMessageAbs("InvalidTypeEntity", "Please your entity needs implements a IEntity interface. You can try extends BaseEntity abstraction.", HandlesCode.InternalException) };
            }
            else
            {
                return new List<IHandleMessage>();
            }
        }

        public IEnumerable<IHandleMessage> AppenData(TEntity entity)
        {
            var checkEntity = CheckEntityType(entity);

            if (checkEntity.Any())
            {
                return checkEntity;
            }

            if (entity.GetType().IsAssignableFrom(typeof(IEntity)))
            {
                var validation = (entity as IEntity)?.Validate();

                if (validation.Any())
                {
                    return validation;
                }
            }

            this._dataset.Append(new List<TEntity>() { entity });

            return new List<IHandleMessage>() { new HandleMessageAbs("AppendData", "Inserted record in provider.", HandlesCode.Accepted) };            
        }

        public IEnumerable<IHandleMessage> DeleteData(TEntity entity)
        {
            var checkEntity = CheckEntityType(entity);

            if (checkEntity.Any())
            {
                return checkEntity;
            }

            var tentity = (IEntity)Convert.ChangeType(entity, typeof(IEntity));
            var check = this._dataset.DeleteRecords(e => (e as IEntity).Id == tentity.Id);

            if (check <= 0)
            {
                return new List<IHandleMessage>() { new HandleMessageAbs("RecordNotFoundException", "Provider not found record.", HandlesCode.ValueNotFound) };
            }

            return new List<IHandleMessage>() { new HandleMessageAbs("DeltedRecord", "Record was removed from data provider.", HandlesCode.Accepted) }; ;
        }

        public void Dispose()
        {
            this._dataset.Dispose();
        }

        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func, int top = 0, int page = 0)
        {
            var result = this._dataset.GetEntities(func, top, page);

            if (result is null)
            {
                return new List<TEntity>();
            }
            else
            {
                return result.ToList();
            }
        }

        public IEnumerable<IHandleMessage> UpdateData(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            var checkEntity = CheckEntityType(entity);

            if (checkEntity.Any())
            {
                return checkEntity;
            }

            var tentity = (IEntity)Convert.ChangeType(entity, typeof(IEntity));
            var validation = tentity.Validate();

            if (validation != null && validation.Any() && validation.Count() > 0)
            {
                return validation;
            }

            var count = this._dataset.UpdateRecords(predicate, entity);

            if (count <= 0)
            {
                return new List<IHandleMessage>() { new HandleMessageAbs("RecordNotFoundException", "Record not found in data provider to change.", HandlesCode.ValueNotFound) };
            }

            return new List<IHandleMessage>() { new HandleMessageAbs("RecordChanged", "The record was changed.", HandlesCode.Accepted) };
        }
    }
}
