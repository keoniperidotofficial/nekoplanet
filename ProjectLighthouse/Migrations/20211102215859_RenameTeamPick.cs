using Microsoft.EntityFrameworkCore.Migrations;
using LBPUnion.ProjectLighthouse;
using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211102215859_RenameTeamPick")]
    public partial class RenameTeamPick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Slots CHANGE `MMPick` `TeamPick` TINYINT(1);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Slots CHANGE `TeamPick` `MMPick` TINYINT(1);");
        }
    }
}
