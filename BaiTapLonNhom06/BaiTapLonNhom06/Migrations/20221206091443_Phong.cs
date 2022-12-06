using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    /// <inheritdoc />
    public partial class Phong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    PhongID = table.Column<string>(type: "TEXT", nullable: false),
                    TienPhong = table.Column<string>(type: "TEXT", nullable: true),
                    CSVC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.PhongID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RommID = table.Column<string>(type: "TEXT", nullable: false),
                    CSVC = table.Column<string>(type: "TEXT", nullable: true),
                    GiaPhong = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RommID);
                });
        }
    }
}
