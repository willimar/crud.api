using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud.api.migration.mysql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Acronym = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    CountryCode = table.Column<int>(nullable: false),
                    IsoCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Population = table.Column<long>(nullable: false),
                    Area = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    InternalName = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    PopularName = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    InternalCode = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    OfficialCode = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    MeasureUnit = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    MinimumStock = table.Column<decimal>(nullable: false),
                    MaximumStock = table.Column<decimal>(nullable: false),
                    Corridor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Bookcase = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Shelf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    CostValue = table.Column<decimal>(nullable: false),
                    SellValue = table.Column<decimal>(nullable: false),
                    Fragile = table.Column<bool>(nullable: false),
                    Packing = table.Column<bool>(nullable: false),
                    QuantityPacking = table.Column<decimal>(nullable: false),
                    GrossWeight = table.Column<decimal>(nullable: false),
                    NetWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Acronym = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    StateCode = table.Column<int>(nullable: false),
                    Population = table.Column<long>(nullable: false),
                    Area = table.Column<decimal>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CityCode = table.Column<int>(nullable: false),
                    StateId = table.Column<Guid>(nullable: true),
                    Population = table.Column<long>(nullable: false),
                    Area = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    NickName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    BirthCityId = table.Column<Guid>(nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    SpecialNeeds = table.Column<bool>(nullable: false),
                    Profession = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    PictureUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_City_BirthCityId",
                        column: x => x.BirthCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<Guid>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    AddressType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryField",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    PersonId1 = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryField_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryField_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryField_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryMesage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryMesage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryMesage_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryMesage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryField_PersonId",
                table: "DictionaryField",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryField_PersonId1",
                table: "DictionaryField",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryField_ProductId",
                table: "DictionaryField",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryMesage_PersonId",
                table: "DictionaryMesage",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryMesage_ProductId",
                table: "DictionaryMesage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthCityId",
                table: "Person",
                column: "BirthCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId",
                table: "Person",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ProductId",
                table: "Person",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DictionaryField");

            migrationBuilder.DropTable(
                name: "DictionaryMesage");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
