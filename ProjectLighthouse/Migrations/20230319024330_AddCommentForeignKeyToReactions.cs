using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230319024330_AddCommentForeignKeyToReactions")]
    public partial class AddCommentForeignKeyToReactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE r FROM Reactions r LEFT JOIN Comments c ON r.TargetId = c.CommentId WHERE c.CommentId IS NULL;");
            migrationBuilder.Sql("ALTER TABLE Reactions CHANGE `TargetId` `CommentId` INT;");

            migrationBuilder.CreateIndex("IX_Reactions_CommentId", "Reactions", "CommentId");
            migrationBuilder.CreateIndex("IX_Reactions_UserId", "Reactions", "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Reactions_Comments_CommentId", "Reactions");
            migrationBuilder.DropForeignKey("FK_Reactions_Users_UserId", "Reactions");
            migrationBuilder.DropIndex("IX_Reactions_CommentId", "Reactions");
            migrationBuilder.DropIndex("IX_Reactions_UserId", "Reactions");
            migrationBuilder.Sql("ALTER TABLE Reactions CHANGE `CommentId` `TargetId` INT;");
        }
    }
}
