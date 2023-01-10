using Microsoft.EntityFrameworkCore.Migrations;

namespace EnginCan.Dal.Migrations
{
    public partial class AboutUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltAciklama",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Yas",
                table: "About",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltAciklama",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Yas",
                table: "About");
        }
    }
}
