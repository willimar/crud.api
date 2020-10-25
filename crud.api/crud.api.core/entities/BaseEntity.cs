using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using crud.api.core.fieldType;
using crud.api.core.interfaces;
using crud.api.core.attributes;
using crud.api.core.exceptions;

namespace crud.api.core.entities
{
    public abstract class BaseEntity: IEntity, IDisposable
    {
        [IsRequiredField]
        public virtual Guid Id { get; set; }
        [IsRequiredField]
        public virtual DateTime RegisterDate { get; set; }
        [IsRequiredField]
        public virtual DateTime LastChangeDate { get; set; }
        [IsRequiredField]
        public virtual RecordStatus Status { get; set; }

        public virtual void Dispose()
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

        public virtual IEnumerable<IHandleMessage> Validate()
        {
            var handles = new List<IHandleMessage>();
            var properties = this.GetType().GetProperties();

            properties.ToList().ForEach(item => {
                if (item.GetCustomAttributes(typeof(IsRequiredFieldAttribute)).Any())
                {
                    var attribute = item.GetCustomAttribute<IsRequiredFieldAttribute>();

                    if (attribute.Required)
                    {
                        var value = item.GetValue(this);
                        var message = $"Field '{item.Name}' is required.";
                        var errorName = nameof(FieldValueException);

                        if (item.PropertyType.Equals(typeof(bool)) && value == null)
                        {
                            handles.Add(new HandleMessage(errorName, message, enums.HandlesCode.InvalidField));
                        }
                        else if (item.PropertyType.IsValueType && Activator.CreateInstance(item.PropertyType).Equals(value) && !item.PropertyType.Equals(typeof(bool)))
                        {
                            handles.Add(new HandleMessage(errorName, message, enums.HandlesCode.InvalidField));
                        }
                        else if (!item.PropertyType.IsValueType && (value == null))
                        {
                            handles.Add(new HandleMessage(errorName, message, enums.HandlesCode.InvalidField));
                        }
                    }
                }
            });

            return handles;
        }
    }
}
