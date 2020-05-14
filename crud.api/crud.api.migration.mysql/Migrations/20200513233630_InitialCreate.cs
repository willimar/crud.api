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
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroup_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                    NickName = table.Column<string>(type: "varchar(30)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    BirthCityId = table.Column<Guid>(nullable: true),
                    Gender = table.Column<string>(type: "varchar(20)", maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(type: "varchar(20)", maxLength: 10, nullable: false),
                    SpecialNeeds = table.Column<bool>(nullable: false),
                    Profession = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: true),
                    PictureUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "PersonAddress",
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
                    table.PrimaryKey("PK_PersonAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAddress_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAddress_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContact_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocument_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonMessage_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonType_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPerson_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthCityId",
                table: "Person",
                column: "BirthCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId",
                table: "Person",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_CityId",
                table: "PersonAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_PersonId",
                table: "PersonDocument",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMessage_PersonId",
                table: "PersonMessage",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonType_PersonId",
                table: "PersonType",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductId",
                table: "ProductGroup",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_ProductId",
                table: "ProductLog",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPerson_PersonId",
                table: "ProductPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPerson_ProductId",
                table: "ProductPerson",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "PersonContact");

            migrationBuilder.DropTable(
                name: "PersonDocument");

            migrationBuilder.DropTable(
                name: "PersonMessage");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "ProductLog");

            migrationBuilder.DropTable(
                name: "ProductPerson");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
