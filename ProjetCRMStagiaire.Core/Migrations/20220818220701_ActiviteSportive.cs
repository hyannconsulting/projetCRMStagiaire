using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Migrations
{
    public partial class ActiviteSportive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiviteSportives",
                columns: table => new
                {
                    ActiviteSportiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    NombreDePlace = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiviteSportives", x => x.ActiviteSportiveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiviteSportives");
        }
    }
}
