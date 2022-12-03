using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    /// <inheritdoc />
    public partial class Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    KhachhangID = table.Column<string>(type: "TEXT", nullable: false),
                    Ten = table.Column<string>(type: "TEXT", nullable: false),
                    MaGioiTinh = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    SĐT = table.Column<string>(type: "TEXT", nullable: false),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    Sophong = table.Column<string>(type: "TEXT", nullable: true),
                    Ngayra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ngayvao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.KhachhangID);
                    table.ForeignKey(
                        name: "FK_Client_GioiTinh_MaGioiTinh",
                        column: x => x.MaGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "MaGioiTinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_MaGioiTinh",
                table: "Client",
                column: "MaGioiTinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
