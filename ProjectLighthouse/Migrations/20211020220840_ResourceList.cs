using Microsoft.EntityFrameworkCore.Migrations;
using LBPUnion.ProjectLighthouse;
using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211020220840_ResourceList")]
    public partial class ResourceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Slots CHANGE `Resource` `ResourceCollection` LONGTEXT;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Slots CHANGE `ResourceCollection` `Resource` LONGTEXT;");
        }
    }
}
