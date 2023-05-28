using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingAPI.Migrations
{
    public partial class changeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingDate",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 101,
                column: "BookingDate",
                value: "28-05-2023 07:46:23 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");
        }
    }
}
