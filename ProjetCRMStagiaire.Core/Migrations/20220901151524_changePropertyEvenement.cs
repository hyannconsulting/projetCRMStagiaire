using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCRMStagiaire.Core.Migrations
{
    public partial class changePropertyEvenement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEvenement",
                table: "Evenements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateEvenement",
                table: "Evenements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
