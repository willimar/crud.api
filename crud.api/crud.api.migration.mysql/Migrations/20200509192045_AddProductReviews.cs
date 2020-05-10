using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud.api.migration.mysql.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Person");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId2",
                table: "DictionaryField",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryField_PersonId2",
                table: "DictionaryField",
                column: "PersonId2");

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryField_Person_PersonId2",
                table: "DictionaryField",
                column: "PersonId2",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryField_Person_PersonId2",
                table: "DictionaryField");

            migrationBuilder.DropIndex(
                name: "IX_DictionaryField_PersonId2",
                table: "DictionaryField");

            migrationBuilder.DropColumn(
                name: "PersonId2",
                table: "DictionaryField");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Person",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
