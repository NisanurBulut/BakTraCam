using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakTraCam.Core.DataAccess.Migrations
{
    public partial class bakimEntityRevizyon1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tBakim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklama = table.Column<string>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    Tarihi = table.Column<DateTime>(nullable: false),
                    Gerceklestiren1 = table.Column<string>(nullable: true),
                    Gerceklestiren2 = table.Column<string>(nullable: true),
                    Gerceklestiren3 = table.Column<string>(nullable: true),
                    Gerceklestiren4 = table.Column<string>(nullable: true),
                    Sorumlu1 = table.Column<string>(nullable: true),
                    Sorumlu2 = table.Column<string>(nullable: true),
                    Oncelik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBakim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tBakimci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBakimci", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tBakim");

            migrationBuilder.DropTable(
                name: "tBakimci");
        }
    }
}
