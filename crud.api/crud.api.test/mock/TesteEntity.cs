using crud.api.core.entities;
using crud.api.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.test.mock
{
    internal class TesteEntity : BaseEntity
    {
        public TesteEntity()
        {
        }

        public override IEnumerable<IHandleMesage> Validate()
        {
            var result = new List<IHandleMesage>();

            if (this.Id == Guid.Empty)
            {
                result.Add(new HandleMessageMock("IdInválido", "Valor inválido para o campo id"));
            }

            if (this.RegisterDate == DateTime.MinValue)
            {
                result.Add(new HandleMessageMock("RegisterDateInvalid", "Valor inválido para  campo data de cadastro."));
            }

            if (this.LastChangeDate == DateTime.MinValue)
            {
                result.Add(new HandleMessageMock("LastChangeDateInvalid", "Valor inválido para  campo data de atualização."));
            }

            return result;
        }
    }
}
