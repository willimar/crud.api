using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.repositories
{
    internal class HandleMessageAbs : IHandleMesage
    {
        public string MesageType { get; }

        public string Mesage { get; }

        public List<string> StackTrace { get; }

        public HandleMessageAbs(string mesageType, string mesage) 
        {
            this.MesageType = mesageType;
            this.Mesage = mesage;
            this.StackTrace = new List<string>();
        }
    }
}
