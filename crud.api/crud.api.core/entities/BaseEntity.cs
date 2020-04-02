using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using crud.api.core.fieldType;
using crud.api.core.interfaces;
using crud.api.core.attributes;
using crud.api.core.eceptions;

namespace crud.api.core.entities
{
    public abstract class BaseEntity: IEntity, IDisposable
    {
        [IsRequiredField]
        public Guid Id { get; set; }
        [IsRequiredField]
        public DateTime RegisterDate { get; set; }
        [IsRequiredField]
        public DateTime LastChangeDate { get; set; }
        [IsRequiredField]
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

        protected bool BaseEquals(IEntity other)
        {
            if (other == null)
            {
                return false;
            }

            if (base.Equals(other))
            {
                return true;
            }

            if (other.Id.Equals(this.Id))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<IHandleMesage> Validate()
        {
            var handles = new List<IHandleMesage>();
            var properties = this.GetType().GetProperties();

            properties.ToList().ForEach(item => {
                if (item.GetCustomAttributes(typeof(IsRequiredFieldAttribute)).Any())
                {
                    var value = item.GetValue(this);
                    var mesage = $"Field '{item.Name}' is required.";
                    var errorName = nameof(FieldValueException);
                    const int code = 404;


                    if (item.PropertyType.IsValueType && Activator.CreateInstance(item.PropertyType).Equals(value))
                    {
                        handles.Add(new HandleMessageAbs(errorName, mesage, code));
                    }
                    else if (!item.PropertyType.IsValueType && (value == null))
                    {
                        handles.Add(new HandleMessageAbs(errorName, mesage, code));
                    }
                }
            });

            return handles;
        }
    }
}
