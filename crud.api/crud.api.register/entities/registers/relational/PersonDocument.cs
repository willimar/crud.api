﻿using crud.api.core.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.entities.registers.relational
{
    public class PersonDocument: DictionaryField
    {
        public virtual Person Person { get; set; }
    }
}