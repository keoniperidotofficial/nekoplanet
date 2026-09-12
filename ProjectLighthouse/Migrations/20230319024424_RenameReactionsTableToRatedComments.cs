using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230319024424_RenameReactionsTableToRatedComments")]
    public partial class RenameReactionsTableToRatedComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // NOTE: the RENAME TABLE already ran and stuck on a previous failed attempt
            // (MySQL DDL isn't transactional), so it's intentionally omitted here.

            migrationBuilder.AddForeignKey(
                name: "FK_RatedComments_Comments_CommentId",
                table: "RatedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatedComments_Users_UserId",
                table: "RatedComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_RatedComments_Comments_CommentId", "RatedComments");
            migrationBuilder.DropForeignKey("FK_RatedComments_Users_UserId", "RatedComments");

            // RENAME TABLE preserves the existing primary key under the new name,
            // so there's no need (and it's invalid) to add a new one here.
            migrationBuilder.Sql("RENAME TABLE RatedComments TO Reactions;");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Comments_CommentId",
                table: "Reactions",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Users_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}