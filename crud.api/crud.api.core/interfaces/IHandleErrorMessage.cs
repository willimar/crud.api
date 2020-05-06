using crud.api.core.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.interfaces
{
    public interface IHandleMessage
    {
        string MessageType { get; }
        string Message { get; }
        HandlesCode Code { get; }
        List<string> StackTrace { get; }
    }
}
