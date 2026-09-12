using LBPUnion.ProjectLighthouse;
using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220216230824_AddEarthHashesForAllGames")]
    public partial class AddEarthHashesForAllGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Users CHANGE `PlanetHash` `PlanetHashLBP2` LONGTEXT;");

            migrationBuilder.AddColumn<string>(
                name: "PlanetHashLBP3",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PlanetHashLBPVita",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanetHashLBP2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlanetHashLBP3",
                table: "Users");

            migrationBuilder.Sql("ALTER TABLE Users CHANGE `PlanetHashLBPVita` `PlanetHash` LONGTEXT;");
        }
    }
}
