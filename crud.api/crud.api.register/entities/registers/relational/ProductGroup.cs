﻿using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.entities.registers.relational
{
    public class ProductGroup : DictionaryField
    {
        public virtual Product Product { get; set; }
    }
}
