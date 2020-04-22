using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.entities
{
    internal class HandleMessageAbs : IHandleMessage
    {
        public string MessageType { get; }

        public string Message { get; }

        public List<string> StackTrace { get; }

        public int Code { get; }

        public HandleMessageAbs(string messageType, string message, int code)
        {
            this.MessageType = messageType;
            this.Message = message;
            this.StackTrace = new List<string>();
            this.Code = code;
        }
    }
}
