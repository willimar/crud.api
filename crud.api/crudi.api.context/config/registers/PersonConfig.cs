using crud.api.register.entities.registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context.config.registers
{
    public class PersonConfig : BaseConfig<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(70)")
                .HasMaxLength(70);

            builder.Property(x => x.NickName)
                .HasColumnType($"{VARCHAR}(30)")
                .HasMaxLength(20);

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(20)")
                .HasMaxLength(10);

            builder.Property(x => x.MaritalStatus)
                .IsRequired()
                .HasColumnType($"{VARCHAR}(20)")
                .HasMaxLength(10);

            builder.Property(x => x.SpecialNeeds)
                .IsRequired();

            builder.Property(x => x.Profession)
                .HasColumnType($"{VARCHAR}(50)")
                .HasMaxLength(15);

            builder.Property(x => x.PictureUrl)
                .HasColumnType($"{VARCHAR}(255)")
                .HasMaxLength(255);

            builder.HasOne(s => s.BirthCity);
            builder.HasMany(s => s.Addresses);
            builder.HasMany(s => s.Dependents);

            builder.HasMany(s => s.Documents).WithOne(f => f.Person);
            builder.HasMany(s => s.Contacts).WithOne(f => f.Person);
            builder.HasMany(s => s.Types).WithOne(f => f.Person);
            builder.HasMany(s => s.Messages).WithOne(f => f.Person);
        }
    }
}
