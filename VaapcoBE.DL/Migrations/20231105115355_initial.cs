using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaapcoBE.DL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsHeadlines",
                columns: table => new
                {
                    HId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadlineLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Posted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsHeadlines", x => x.HId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsHeadlines");
        }
    }
}
