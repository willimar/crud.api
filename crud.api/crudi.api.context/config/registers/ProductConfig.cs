using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(70)")
                .HasMaxLength(70);

            builder.Property(x => x.InternalName)
                .HasColumnType($"{VARCHAR}(70)")
                .HasMaxLength(70);

            builder.Property(x => x.PopularName)
                .HasColumnType($"{VARCHAR}(70)")
                .HasMaxLength(70);

            builder.Property(x => x.InternalCode)
                .HasColumnType($"{VARCHAR}(150)")
                .HasMaxLength(150);

            builder.Property(x => x.OfficialCode)
                .HasColumnType($"{VARCHAR}(150)")
                .HasMaxLength(150);

            builder.Property(x => x.MeasureUnit)
                .HasColumnType($"{VARCHAR}(5)")
                .HasMaxLength(5);

            builder.Property(x => x.Corridor)
                .HasColumnType($"{VARCHAR}(15)")
                .HasMaxLength(15);

            builder.Property(x => x.Bookcase)
                .HasColumnType($"{VARCHAR}(15)")
                .HasMaxLength(15);

            builder.Property(x => x.Shelf)
                .HasColumnType($"{VARCHAR}(15)")
                .HasMaxLength(15);

            builder.Property(x => x.Fragile)
                .IsRequired();

            builder.Property(x => x.Packing)
                .IsRequired();

            builder.HasMany(s => s.ProductGroups).WithOne(f => f.Product);
            builder.HasMany(s => s.ProductLog).WithOne(f => f.Product);
            builder.HasMany(s => s.Providers).WithOne(f => f.Product);
        }
    }
}
