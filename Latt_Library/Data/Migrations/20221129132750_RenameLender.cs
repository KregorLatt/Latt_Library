using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latt_Library.Data.Migrations
{
    public partial class RenameLender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_LendersId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LendersId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LendersId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Lending",
                table: "Book");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_LenderId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LenderId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "LendersId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lending",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LendersId",
                table: "Book",
                column: "LendersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookLender_LendersId",
                table: "Book",
                column: "LendersId",
                principalTable: "BookLender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
