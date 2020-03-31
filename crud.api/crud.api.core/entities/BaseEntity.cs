using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using crud.api.core.fieldType;
using crud.api.core.interfaces;

namespace crud.api.core.entities
{
    public abstract class BaseEntity: IEntity, IDisposable, IEquatable<IEntity>
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public RecordStatus Status { get; set; }

        public void Dispose()
        {
            var properties = this.GetType().GetProperties();

            foreach (var item in properties)
            {
                if (item.GetType().GetInterfaces().Contains(typeof(IDisposable)))
                {
                    (item as IDisposable).Dispose();
                }
                else
                {
                    //item.SetValue(this, default(typeof(item.GetType()));
                }
            }
        }

        public bool Equals(IEntity other)
        {
            return other.Id.Equals(this.Id);
        }

        public abstract IEnumerable<IHandleMesage> Validate();
    }
}
