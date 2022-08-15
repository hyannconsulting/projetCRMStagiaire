using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Data.Migrations
{
    public partial class updateinscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StagiaireId",
                table: "Inscriptions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_StagiaireId",
                table: "Inscriptions",
                column: "StagiaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_AspNetUsers_StagiaireId",
                table: "Inscriptions",
                column: "StagiaireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_AspNetUsers_StagiaireId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_StagiaireId",
                table: "Inscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "StagiaireId",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
