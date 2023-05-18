using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestataires",
                columns: table => new
                {
                    PrestataireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    PageInstagram = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrestataireNom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrestataireTel = table.Column<int>(type: "int", nullable: false),
                    zone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestataires", x => x.PrestataireId);
                });

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    PrestationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrestationType = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    PrestataireFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.PrestationId);
                    table.ForeignKey(
                        name: "FK_Prestations_Prestataires_PrestataireFK",
                        column: x => x.PrestataireFK,
                        principalTable: "Prestataires",
                        principalColumn: "PrestataireId");
                });

            migrationBuilder.CreateTable(
                name: "RDVs",
                columns: table => new
                {
                    DateRDV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    PrestationFK = table.Column<int>(type: "int", nullable: false),
                    Confirmation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RDVs", x => new { x.ClientFK, x.PrestationFK, x.DateRDV });
                    table.ForeignKey(
                        name: "FK_RDVs_Clients_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RDVs_Prestations_PrestationFK",
                        column: x => x.PrestationFK,
                        principalTable: "Prestations",
                        principalColumn: "PrestationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestations_PrestataireFK",
                table: "Prestations",
                column: "PrestataireFK");

            migrationBuilder.CreateIndex(
                name: "IX_RDVs_PrestationFK",
                table: "RDVs",
                column: "PrestationFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RDVs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DropTable(
                name: "Prestataires");
        }
    }
}
