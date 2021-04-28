using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakTraCam.Core.DataAccess.Migrations
{
    public partial class insert_duyuru_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Tarihi",
                table: "Bakims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "tDuyuru",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aciklama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDuyuru", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tDuyuru");

            migrationBuilder.DropColumn(
                name: "Tarihi",
                table: "Bakims");
        }
    }
}
