using crud.api.core.enums;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.entities
{
    internal class HandleMessageAbs : IHandleMessage
    {
        public string MessageType { get; }

        public string Message { get; }

        public List<string> StackTrace { get; }

        public HandlesCode Code { get; }

        public HandleMessageAbs(string messageType, string message, HandlesCode code)
        {
            this.MessageType = messageType;
            this.Message = message;
            this.StackTrace = new List<string>();
            this.Code = code;
        }
    }
}
