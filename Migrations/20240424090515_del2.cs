using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class del2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Feed_feedId1",
                table: "UserFeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Res_resId1",
                table: "UserFeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserFeeds_feedId1",
                table: "UserFeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserFeeds_resId1",
                table: "UserFeeds");

            migrationBuilder.DropColumn(
                name: "feedId1",
                table: "UserFeeds");

            migrationBuilder.DropColumn(
                name: "resId1",
                table: "UserFeeds");

            migrationBuilder.AlterColumn<Guid>(
                name: "resId",
                table: "UserFeeds",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "feedId",
                table: "UserFeeds",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_feedId",
                table: "UserFeeds",
                column: "feedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_resId",
                table: "UserFeeds",
                column: "resId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Feed_feedId",
                table: "UserFeeds",
                column: "feedId",
                principalTable: "Feed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Res_resId",
                table: "UserFeeds",
                column: "resId",
                principalTable: "Res",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Feed_feedId",
                table: "UserFeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Res_resId",
                table: "UserFeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserFeeds_feedId",
                table: "UserFeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserFeeds_resId",
                table: "UserFeeds");

            migrationBuilder.AlterColumn<string>(
                name: "resId",
                table: "UserFeeds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "feedId",
                table: "UserFeeds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "feedId1",
                table: "UserFeeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "resId1",
                table: "UserFeeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_feedId1",
                table: "UserFeeds",
                column: "feedId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_resId1",
                table: "UserFeeds",
                column: "resId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Feed_feedId1",
                table: "UserFeeds",
                column: "feedId1",
                principalTable: "Feed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Res_resId1",
                table: "UserFeeds",
                column: "resId1",
                principalTable: "Res",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
