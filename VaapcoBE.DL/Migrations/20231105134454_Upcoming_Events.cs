using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaapcoBE.DL.Migrations
{
    public partial class Upcoming_Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpcomingEvents",
                columns: table => new
                {
                    EId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventVenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventAddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpcomingEvents", x => x.EId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpcomingEvents");
        }
    }
}
