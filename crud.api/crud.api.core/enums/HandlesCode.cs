using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.enums
{
    public enum HandlesCode
    {
        Accepted = 202,
        Ok = 200,
        InvalidField = 401,
        EmptyField = 402,
        ValueNotFound = 404,
        InternalException = 501,
        ManyRecordsFound = 405
    }
}
