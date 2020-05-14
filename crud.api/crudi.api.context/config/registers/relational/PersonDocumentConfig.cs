using crud.api.register.entities.registers.relational;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers.relational
{
    public class PersonDocumentConfig : BaseConfig<PersonDocument>
    {
        public override void Configure(EntityTypeBuilder<PersonDocument> builder)
        {
            
        }
    }
}
