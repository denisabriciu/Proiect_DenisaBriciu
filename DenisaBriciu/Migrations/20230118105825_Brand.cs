using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_DenisaBriciu.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandID",
                table: "Car",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Car_BrandID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Car");
        }
    }
}
