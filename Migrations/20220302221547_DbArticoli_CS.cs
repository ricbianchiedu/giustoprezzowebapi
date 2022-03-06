using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiustoPrezzo.Migrations
{
    public partial class DbArticoli_CS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Categoria_FK_Categoria",
                table: "Articoli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Categorie_FK_Categoria",
                table: "Articoli",
                column: "FK_Categoria",
                principalTable: "Categorie",
                principalColumn: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Categorie_FK_Categoria",
                table: "Articoli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Categoria_FK_Categoria",
                table: "Articoli",
                column: "FK_Categoria",
                principalTable: "Categoria",
                principalColumn: "CategoriaID");
        }
    }
}
