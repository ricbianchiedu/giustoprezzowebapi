using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiustoPrezzo.Migrations
{
    public partial class FKName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Categorie_FK_Categoria",
                table: "Articoli");

            migrationBuilder.RenameColumn(
                name: "FK_Categoria",
                table: "Articoli",
                newName: "CategoriaID");

            migrationBuilder.RenameIndex(
                name: "IX_Articoli_FK_Categoria",
                table: "Articoli",
                newName: "IX_Articoli_CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Categorie_CategoriaID",
                table: "Articoli",
                column: "CategoriaID",
                principalTable: "Categorie",
                principalColumn: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Categorie_CategoriaID",
                table: "Articoli");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "Articoli",
                newName: "FK_Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Articoli_CategoriaID",
                table: "Articoli",
                newName: "IX_Articoli_FK_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Categorie_FK_Categoria",
                table: "Articoli",
                column: "FK_Categoria",
                principalTable: "Categorie",
                principalColumn: "CategoriaID");
        }
    }
}
