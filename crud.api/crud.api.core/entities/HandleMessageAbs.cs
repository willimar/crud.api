using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.entities
{
    internal class HandleMessageAbs : IHandleMesage
    {
        public string MesageType { get; }

        public string Mesage { get; }

        public List<string> StackTrace { get; }

        public int Code { get; }

        public HandleMessageAbs(string mesageType, string mesage, int code)
        {
            this.MesageType = mesageType;
            this.Mesage = mesage;
            this.StackTrace = new List<string>();
            this.Code = code;
        }
    }
}
