using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Migrations
{
    public partial class ActiviteSportive_inscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiviteSportiveId",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdActiviteSportive",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ActiviteSportiveId",
                table: "Inscriptions",
                column: "ActiviteSportiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_ActiviteSportives_ActiviteSportiveId",
                table: "Inscriptions",
                column: "ActiviteSportiveId",
                principalTable: "ActiviteSportives",
                principalColumn: "ActiviteSportiveId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_ActiviteSportives_ActiviteSportiveId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_ActiviteSportiveId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "ActiviteSportiveId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "IdActiviteSportive",
                table: "Inscriptions");
        }
    }
}
