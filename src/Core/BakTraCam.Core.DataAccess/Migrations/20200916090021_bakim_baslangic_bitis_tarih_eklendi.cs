using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakTraCam.Core.DataAccess.Migrations
{
    public partial class bakim_baslangic_bitis_tarih_eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bakims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklama = table.Column<string>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false),
                    Gerceklestiren1 = table.Column<string>(nullable: true),
                    Gerceklestiren2 = table.Column<string>(nullable: true),
                    Gerceklestiren3 = table.Column<string>(nullable: true),
                    Gerceklestiren4 = table.Column<string>(nullable: true),
                    Sorumlu1 = table.Column<string>(nullable: true),
                    Sorumlu2 = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    Durum = table.Column<int>(nullable: false),
                    Tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bakims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tBakim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklama = table.Column<string>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    Tarihi = table.Column<DateTime>(nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false),
                    Gerceklestiren1 = table.Column<int>(nullable: false),
                    Gerceklestiren2 = table.Column<int>(nullable: false),
                    Gerceklestiren3 = table.Column<int>(nullable: false),
                    Gerceklestiren4 = table.Column<int>(nullable: false),
                    Sorumlu1 = table.Column<int>(nullable: false),
                    Sorumlu2 = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Durum = table.Column<int>(nullable: false),
                    Tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBakim", x => x.Id);
                });

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
                name: "Bakims");

            migrationBuilder.DropTable(
                name: "tBakim");

            migrationBuilder.DropTable(
                name: "tKullanici");
        }
    }
}
