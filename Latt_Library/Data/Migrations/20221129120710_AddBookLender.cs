using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latt_Library.Data.Migrations
{
    public partial class AddBookLender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Book",
                newName: "Lending");

            migrationBuilder.AddColumn<int>(
                name: "LenderId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LendersId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookLender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ssId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLender", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLender_LendersId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookLender");

            migrationBuilder.DropIndex(
                name: "IX_Book_LendersId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LenderId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LendersId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Lending",
                table: "Book",
                newName: "Name");
        }
    }
}
