using Microsoft.EntityFrameworkCore.Migrations;

namespace BakTraCam.Core.DataAccess.Migrations
{
    public partial class tkullanici_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tBakimci");

            migrationBuilder.CreateTable(
                name: "tKullanici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    UnvanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tKullanici", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tKullanici");

            migrationBuilder.CreateTable(
                name: "tBakimci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBakimci", x => x.Id);
                });
        }
    }
}
