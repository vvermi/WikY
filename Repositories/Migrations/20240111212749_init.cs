using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMod = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Auteur", "Contenu", "DateCre", "DateMod", "Theme" },
                values: new object[,]
                {
                    { 1, "Lilyah", "Rien", new DateTime(2012, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Les Réseaux Sociaux" },
                    { 2, "Kezyah", "Y en a plein, c'est beau une licorne", new DateTime(2016, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Des licornes dans les contes de fées" },
                    { 3, "Wakko", "But does it djent ?", new DateTime(1981, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C# rocks !" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ArticleId",
                table: "Commentaires",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
