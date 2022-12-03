using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    /// <inheritdoc />
    public partial class Room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RommID = table.Column<string>(type: "TEXT", nullable: false),
                    MaGiaPhong = table.Column<string>(type: "TEXT", nullable: true),
                    CSVC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RommID);
                    table.ForeignKey(
                        name: "FK_Room_GiaPhong_MaGiaPhong",
                        column: x => x.MaGiaPhong,
                        principalTable: "GiaPhong",
                        principalColumn: "MaGiaPhong");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_MaGiaPhong",
                table: "Room",
                column: "MaGiaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
