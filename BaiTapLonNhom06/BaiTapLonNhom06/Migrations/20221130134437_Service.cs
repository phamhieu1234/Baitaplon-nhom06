using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    /// <inheritdoc />
    public partial class Service : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Drinks_MaDrinks",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Food_MaFood",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Haircuts_MaHaircuts",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Haircuts");

            migrationBuilder.DropIndex(
                name: "IX_Service_MaDrinks",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_MaFood",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_MaHaircuts",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "MaHaircuts",
                table: "Service",
                newName: "HaircutName");

            migrationBuilder.RenameColumn(
                name: "MaFood",
                table: "Service",
                newName: "FoodName");

            migrationBuilder.RenameColumn(
                name: "MaDrinks",
                table: "Service",
                newName: "DrinkName");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Service",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Service",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServicePrice",
                table: "Service",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "HaircutName",
                table: "Service",
                newName: "MaHaircuts");

            migrationBuilder.RenameColumn(
                name: "FoodName",
                table: "Service",
                newName: "MaFood");

            migrationBuilder.RenameColumn(
                name: "DrinkName",
                table: "Service",
                newName: "MaDrinks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    MaDrinks = table.Column<string>(type: "TEXT", nullable: false),
                    TenDrinks = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.MaDrinks);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    MaFood = table.Column<string>(type: "TEXT", nullable: false),
                    TenFood = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.MaFood);
                });

            migrationBuilder.CreateTable(
                name: "Haircuts",
                columns: table => new
                {
                    MaHaircuts = table.Column<string>(type: "TEXT", nullable: false),
                    TenHaircuts = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haircuts", x => x.MaHaircuts);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_MaDrinks",
                table: "Service",
                column: "MaDrinks");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MaFood",
                table: "Service",
                column: "MaFood");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MaHaircuts",
                table: "Service",
                column: "MaHaircuts");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Drinks_MaDrinks",
                table: "Service",
                column: "MaDrinks",
                principalTable: "Drinks",
                principalColumn: "MaDrinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Food_MaFood",
                table: "Service",
                column: "MaFood",
                principalTable: "Food",
                principalColumn: "MaFood");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Haircuts_MaHaircuts",
                table: "Service",
                column: "MaHaircuts",
                principalTable: "Haircuts",
                principalColumn: "MaHaircuts");
        }
    }
}
