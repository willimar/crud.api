using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.test.mock
{
    internal class HandleMessageMock : IHandleMesage
    {
        public string MesageType { get; }

        public string Mesage { get; }

        public List<string> StackTrace => new List<string>();

        public int Code { get; }

        public HandleMessageMock(string type, string mesage) {
            MesageType = type;
            Mesage = mesage;
        }

    }
}
