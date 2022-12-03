using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    /// <inheritdoc />
    public partial class GiaPhong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaPhong",
                columns: table => new
                {
                    MaGiaPhong = table.Column<string>(type: "TEXT", nullable: false),
                    TenGiaPhong = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaPhong", x => x.MaGiaPhong);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaPhong");
        }
    }
}
