using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latt_Library.Data.Migrations
{
    public partial class FixDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_BookLenderId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookLenderId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "IsLended",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "BookLenderId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Lending",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookLenderId",
                table: "Lending",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLended",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Lending_BookId",
                table: "Lending",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Lending_BookLenderId",
                table: "Lending",
                column: "BookLenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Book_BookId",
                table: "Lending",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_BookLender_BookLenderId",
                table: "Lending",
                column: "BookLenderId",
                principalTable: "BookLender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Book_BookId",
                table: "Lending");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_BookLender_BookLenderId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_BookId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_BookLenderId",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "BookLenderId",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "IsLended",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Lending",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsLended",
                table: "Lending",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lending",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BookLenderId",
                table: "Book",
                type: "int",
                nullable: true);

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
    }
}
