using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class DictionaryFieldConfig : BaseConfig<DictionaryField>
    {
        public override void Configure(EntityTypeBuilder<DictionaryField> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType($"{VARCHAR}(15)");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(100)")
                .HasMaxLength(100);
        }
    }
}
