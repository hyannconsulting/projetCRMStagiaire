using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Migrations
{
    public partial class Inscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StagiaireId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscriptionId);
                    table.ForeignKey(
                        name: "FK_Inscriptions_AspNetUsers_StagiaireId",
                        column: x => x.StagiaireId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_StagiaireId",
                table: "Inscriptions",
                column: "StagiaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");
        }
    }
}
