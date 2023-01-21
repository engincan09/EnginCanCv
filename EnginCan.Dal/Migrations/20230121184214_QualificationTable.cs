using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnginCan.Dal.Migrations
{
    public partial class QualificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserId = table.Column<int>(nullable: true),
                    LastUpdatedUserId = table.Column<int>(nullable: true),
                    DataStatus = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    QualificationType = table.Column<int>(nullable: false),
                    Donem = table.Column<string>(nullable: true),
                    Baslik = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualification");
        }
    }
}
