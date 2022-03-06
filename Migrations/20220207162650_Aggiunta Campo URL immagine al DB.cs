using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiustoPrezzo.Migrations
{
    public partial class AggiuntaCampoURLimmaginealDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Articoli",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Articoli",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Articoli");

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Articoli",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
