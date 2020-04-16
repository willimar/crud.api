﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crud.api.migration.mysql;

namespace crud.api.migration.mysql.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("crud.api.register.entities.registers.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<Guid?>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Complement")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("CityCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<string>("IsoCode")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.DictionaryField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PersonId1")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("ProductId");

                    b.ToTable("DictionaryField");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.DictionaryMesage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("DictionaryMesage");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("BirthCityId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("NickName")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Profession")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("SpecialNeeds")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("BirthCityId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bookcase")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Corridor")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<decimal>("CostValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("Fragile")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("GrossWeight")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("InternalCode")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("InternalName")
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("MaximumStock")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("MeasureUnit")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal>("MinimumStock")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<decimal>("NetWeight")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OfficialCode")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("Packing")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PopularName")
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<decimal>("QuantityPacking")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("SellValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Shelf")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("StateCode")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.Address", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("crud.api.register.entities.registers.Person", null)
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.City", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.DictionaryField", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.Person", null)
                        .WithMany("Contacts")
                        .HasForeignKey("PersonId");

                    b.HasOne("crud.api.register.entities.registers.Person", null)
                        .WithMany("Documents")
                        .HasForeignKey("PersonId1");

                    b.HasOne("crud.api.register.entities.registers.Product", null)
                        .WithMany("ProductGroups")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.DictionaryMesage", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.Person", null)
                        .WithMany("Mesages")
                        .HasForeignKey("PersonId");

                    b.HasOne("crud.api.register.entities.registers.Product", null)
                        .WithMany("ProductLog")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.Person", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.City", "BirthCity")
                        .WithMany()
                        .HasForeignKey("BirthCityId");

                    b.HasOne("crud.api.register.entities.registers.Person", null)
                        .WithMany("Dependents")
                        .HasForeignKey("PersonId");

                    b.HasOne("crud.api.register.entities.registers.Product", null)
                        .WithMany("Providers")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("crud.api.register.entities.registers.State", b =>
                {
                    b.HasOne("crud.api.register.entities.registers.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}