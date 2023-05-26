using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomsAPI.Migrations
{
    public partial class roominitmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomStatus = table.Column<bool>(type: "bit", nullable: false),
                    RoomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "HotelId", "RoomDescription", "RoomStatus", "RoomType" },
                values: new object[] { 101, 101, "AC/Room Service/Wi-fi", true, "Single" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
