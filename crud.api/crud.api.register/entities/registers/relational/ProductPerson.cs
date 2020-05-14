using crud.api.core.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.entities.registers.relational
{
    public class ProductPerson: BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Person Person { get; set; }
    }
}
