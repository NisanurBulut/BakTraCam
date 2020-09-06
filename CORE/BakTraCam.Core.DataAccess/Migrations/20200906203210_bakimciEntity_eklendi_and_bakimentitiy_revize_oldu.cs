using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakTraCam.Core.DataAccess.Migrations
{
    public partial class bakimciEntity_eklendi_and_bakimentitiy_revize_oldu : Migration
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
                    Ad = table.Column<string>(nullable: true),
                    BakimEntityId = table.Column<int>(nullable: true),
                    BakimEntityId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBakimci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tBakimci_tBakim_BakimEntityId",
                        column: x => x.BakimEntityId,
                        principalTable: "tBakim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tBakimci_tBakim_BakimEntityId1",
                        column: x => x.BakimEntityId1,
                        principalTable: "tBakim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tBakimci_BakimEntityId",
                table: "tBakimci",
                column: "BakimEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_tBakimci_BakimEntityId1",
                table: "tBakimci",
                column: "BakimEntityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tBakimci");

            migrationBuilder.DropTable(
                name: "tBakim");
        }
    }
}
