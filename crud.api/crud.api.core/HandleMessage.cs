using crud.api.core.enums;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud.api.core
{
    public class HandleMessage : IHandleMessage
    {
        public string MessageType { get; }

        public string Message { get; }

        public List<string> StackTrace { get; }

        public HandlesCode Code { get; }

        public HandleMessage(string messageType, string message, HandlesCode code)
        {
            this.MessageType = messageType;
            this.Message = message;
            this.StackTrace = new List<string>();
            this.Code = code;
        }

        public HandleMessage(Exception e)
        {
            this.Code = HandlesCode.InternalException;
            this.MessageType = e.GetType().Name;
            this.Message = e.Message;
            char splitFlag = ' ';
            this.StackTrace = e.StackTrace?.Split(splitFlag).ToList();
        }
    }
}
