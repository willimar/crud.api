using crud.api.core.fieldType;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime RegisterDate { get; set; }
        DateTime LastChangeDate { get; set; }
        RecordStatus Status { get; set; }

        IEnumerable<IHandleMessage> Validate();
    }
}
