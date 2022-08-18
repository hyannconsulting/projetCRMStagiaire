using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Migrations
{
    public partial class addEvenement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    EvenementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiviteSportiveId = table.Column<int>(type: "int", nullable: false),
                    DateEvenement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.EvenementId);
                    table.ForeignKey(
                        name: "FK_Evenements_ActiviteSportives_ActiviteSportiveId",
                        column: x => x.ActiviteSportiveId,
                        principalTable: "ActiviteSportives",
                        principalColumn: "ActiviteSportiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_ActiviteSportiveId",
                table: "Evenements",
                column: "ActiviteSportiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evenements");
        }
    }
}
