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

        public IEnumerable<IHandleMessage> SaveData(TEntity entity)
        {
            var data = entity as IEntity;
            data.LastChangeDate = DateTime.UtcNow;
            data.Status = fieldType.RecordStatus.Active;

            if (Exists(data))
            {
                return this._repository.UpdateData(data as TEntity, e => e.Equals(data));
            }
            else
            {
                data.RegisterDate = DateTime.UtcNow;

                return this._repository.AppenData(data as TEntity);
            }
        }

        private bool Exists(IEntity entity)
        {
            var data = this.GetData(e => e.Equals(entity)).FirstOrDefault();

            return data == null ? false : true;
        }

        public IEnumerable<IHandleMessage> DeleteData(TEntity entity, bool remove = false)
        {
            if (remove)
            {
                return this._repository.DeleteData(entity);
            }
            else
            {
                var entities = this.GetData(e => (e as IEntity).Id.Equals((entity as IEntity).Id)) as List<IEntity>;

                if (!Convert.ToBoolean( entities?.Any()))
                {
                    return new List<IHandleMessage>() { new HandleMessageAbs("RecordNotFoundException", $"The record with id {(entity as IEntity).Id} wasn't found in database.", enums.HandlesCode.ValueNotFound) };
                }
                else if (entities.Count() > 1)
                {
                    return new List<IHandleMessage>() { new HandleMessageAbs("ManyRecordsFoundException", $"It's impossible but we found lot of records ({entities.Count()} records) with id {(entity as IEntity).Id} in the database.", enums.HandlesCode.ManyRecordsFound) };
                }
                else if (entities.Count() == 1)
                {
                    var data = entities.FirstOrDefault() as IEntity;
                    data.Status = fieldType.RecordStatus.Deleted;
                    return this._repository.UpdateData(data as TEntity, e => (e as IEntity).Id.Equals(data.Id));
                }
                else
                {
                    return new List<IHandleMessage>() { new HandleMessageAbs("CatastroficFailException", "Ops. but happened a inprevisible error. :-o.", enums.HandlesCode.InternalException) };
                }
            }
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> func, int top = 0, int page = 0)
        {
            return this._repository.GetData(func, top, page);
        }
    }
}
