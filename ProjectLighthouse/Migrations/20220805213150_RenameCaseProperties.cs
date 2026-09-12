using System;
using LBPUnion.ProjectLighthouse;
using LBPUnion.ProjectLighthouse.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220805213150_RenameCaseProperties")]
    public partial class RenameCaseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cases;");

            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CaseType` `Type` VARCHAR(255);");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CaseExpires` `ExpiresAt` DATETIME;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CaseDescription` `Description` LONGTEXT;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CaseCreatorId` `CreatorId` INT;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CaseCreated` `CreatedAt` DATETIME;");

            migrationBuilder.AddColumn<DateTime>(
                name: "DismissedAt",
                table: "Cases",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DismisserId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DismisserId",
                table: "Cases",
                column: "DismisserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_CreatorId",
                table: "Cases",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_DismisserId",
                table: "Cases",
                column: "DismisserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Cases_Users_CreatorId", "Cases");
            migrationBuilder.DropForeignKey("FK_Cases_Users_DismisserId", "Cases");
            migrationBuilder.DropIndex("IX_Cases_DismisserId", "Cases");
            migrationBuilder.DropColumn("DismissedAt", "Cases");
            migrationBuilder.DropColumn("DismisserId", "Cases");

            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `Type` `CaseType` VARCHAR(255);");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `ExpiresAt` `CaseExpires` DATETIME;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `Description` `CaseDescription` LONGTEXT;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CreatorId` `CaseCreatorId` INT;");
            migrationBuilder.Sql("ALTER TABLE Cases CHANGE `CreatedAt` `CaseCreated` DATETIME;");

            migrationBuilder.AddColumn<bool>(
                name: "Banned",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_CaseCreatorId",
                table: "Cases",
                column: "CaseCreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
