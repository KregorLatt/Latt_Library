using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latt_Library.Data.Migrations
{
    public partial class ChangeRentToRentDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rent",
                table: "Book",
                newName: "RentDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentDays",
                table: "Book",
                newName: "Rent");
        }
    }
}
