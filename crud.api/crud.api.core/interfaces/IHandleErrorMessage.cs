using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.interfaces
{
    public interface IHandleMesage
    {
        string MesageType { get; }
        string Mesage { get; }
        int Code { get; }
        List<string> StackTrace { get; }
    }
}
