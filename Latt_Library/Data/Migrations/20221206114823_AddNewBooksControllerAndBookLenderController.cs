using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latt_Library.Data.Migrations
{
    public partial class AddNewBooksControllerAndBookLenderController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_LenderId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LenderId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "RentalLenght",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "LenderId",
                table: "Book",
                newName: "Rent");

            migrationBuilder.AddColumn<int>(
                name: "BookLenderId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookLenderId",
                table: "Book",
                column: "BookLenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookLender_BookLenderId",
                table: "Book",
                column: "BookLenderId",
                principalTable: "BookLender",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_BookLenderId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookLenderId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookLenderId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Rent",
                table: "Book",
                newName: "LenderId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalLenght",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_LenderId",
                table: "Book",
                column: "LenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookLender_LenderId",
                table: "Book",
                column: "LenderId",
                principalTable: "BookLender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
