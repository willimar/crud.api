using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class AddressConfig: BaseConfig<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.AddressType)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(30)")
                .HasMaxLength(30);

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(20)")
                .HasMaxLength(20);
        }
    }
}
