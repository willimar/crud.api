using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class CountryConfig : BaseConfig<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Acronym)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(3)")
                .HasMaxLength(3);

            builder.Property(x => x.IsoCode)
                .HasColumnType($"{VARCHAR}(15)")
                .HasMaxLength(15);


        }
    }
}
