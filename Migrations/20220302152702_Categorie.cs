using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiustoPrezzo.Migrations
{
    public partial class Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_Categoria",
                table: "Articoli",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_FK_Categoria",
                table: "Articoli",
                column: "FK_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Categoria_FK_Categoria",
                table: "Articoli",
                column: "FK_Categoria",
                principalTable: "Categoria",
                principalColumn: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Categoria_FK_Categoria",
                table: "Articoli");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Articoli_FK_Categoria",
                table: "Articoli");

            migrationBuilder.DropColumn(
                name: "FK_Categoria",
                table: "Articoli");
        }
    }
}
