using crud.api.core.enums;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.test.mock
{
    internal class HandleMessageMock : IHandleMessage
    {
        public string MessageType { get; }

        public string Message { get; }

        public List<string> StackTrace => new List<string>();

        public HandlesCode Code { get; }

        public HandleMessageMock(string type, string message, HandlesCode code) {
            MessageType = type;
            Message = message;
            Code = code;
        }

    }
}
