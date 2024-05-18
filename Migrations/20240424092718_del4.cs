using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class del4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Feed_feedId1",
                table: "UserFeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Res_resId1",
                table: "UserFeeds");

            migrationBuilder.RenameColumn(
                name: "resId1",
                table: "UserFeeds",
                newName: "resId");

            migrationBuilder.RenameColumn(
                name: "feedId1",
                table: "UserFeeds",
                newName: "feedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeeds_resId1",
                table: "UserFeeds",
                newName: "IX_UserFeeds_resId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeeds_feedId1",
                table: "UserFeeds",
                newName: "IX_UserFeeds_feedId");

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

            migrationBuilder.RenameColumn(
                name: "resId",
                table: "UserFeeds",
                newName: "resId1");

            migrationBuilder.RenameColumn(
                name: "feedId",
                table: "UserFeeds",
                newName: "feedId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeeds_resId",
                table: "UserFeeds",
                newName: "IX_UserFeeds_resId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeeds_feedId",
                table: "UserFeeds",
                newName: "IX_UserFeeds_feedId1");

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
