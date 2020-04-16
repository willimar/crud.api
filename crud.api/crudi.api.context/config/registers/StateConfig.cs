using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class StateConfig : BaseConfig<State>
    {
        public override void Configure(EntityTypeBuilder<State> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(70)")
                .HasMaxLength(70);

            builder.Property(x => x.Acronym)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(2)")
                .HasMaxLength(2);
        }
    }
}
