using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class DictionaryMesageConfig : BaseConfig<DictionaryMesage>
    {
        public override void Configure(EntityTypeBuilder<DictionaryMesage> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(255)")
                .HasMaxLength(255);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(15)")
                .HasMaxLength(15);
        }
    }
}
