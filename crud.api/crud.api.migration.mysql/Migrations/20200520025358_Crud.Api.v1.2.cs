using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud.api.migration.mysql.Migrations
{
    public partial class CrudApiv12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonAddress_City_CityId",
                table: "PersonAddress");

            migrationBuilder.DropIndex(
                name: "IX_PersonAddress_CityId",
                table: "PersonAddress");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PersonAddress");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonAddress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "PersonAddress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PersonAddress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonAddress");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "PersonAddress");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PersonAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "PersonAddress",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_CityId",
                table: "PersonAddress",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAddress_City_CityId",
                table: "PersonAddress",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
