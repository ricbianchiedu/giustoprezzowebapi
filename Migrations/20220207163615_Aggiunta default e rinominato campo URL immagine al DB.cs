using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiustoPrezzo.Migrations
{
    public partial class AggiuntadefaulterinominatocampoURLimmaginealDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Articoli",
                newName: "UrlImmagine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlImmagine",
                table: "Articoli",
                newName: "URL");
        }
    }
}
