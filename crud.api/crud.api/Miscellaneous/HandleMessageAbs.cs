﻿using crud.api.core.enums;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace crud.api.Miscellaneous
{
    internal class HandleMessageAbs : IHandleMessage
    {
        public HandleMessageAbs()
        {

        }

        public HandleMessageAbs(Exception e)
        {
            this.Code = HandlesCode.InternalException;
            this.MessageType = e.GetType().Name;
            this.Message = e.Message;
            this.StackTrace = e.StackTrace?.Split("/n").ToList();
        }

        public string MessageType { get; private set; }

        public string Message { get; private set; }

        public HandlesCode Code { get; private set; }

        public List<string> StackTrace { get; private set; }

        public static IHandleMessage Factory(HandlesCode code, string message, string messageType)
        {
            return new HandleMessageAbs() { 
                Code = code,
                Message = message,
                MessageType = messageType
            };
        }
    }
}
