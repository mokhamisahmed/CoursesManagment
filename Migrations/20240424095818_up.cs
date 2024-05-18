using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFeeds");

            migrationBuilder.AddColumn<Guid>(
                name: "responseId",
                table: "Feed",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Feed",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feed_responseId",
                table: "Feed",
                column: "responseId");

            migrationBuilder.CreateIndex(
                name: "IX_Feed_userId",
                table: "Feed",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feed_AspNetUsers_userId",
                table: "Feed",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feed_Response_responseId",
                table: "Feed",
                column: "responseId",
                principalTable: "Response",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feed_AspNetUsers_userId",
                table: "Feed");

            migrationBuilder.DropForeignKey(
                name: "FK_Feed_Response_responseId",
                table: "Feed");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Feed_responseId",
                table: "Feed");

            migrationBuilder.DropIndex(
                name: "IX_Feed_userId",
                table: "Feed");

            migrationBuilder.DropColumn(
                name: "responseId",
                table: "Feed");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Feed");

            migrationBuilder.CreateTable(
                name: "UserFeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    resId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeeds_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeeds_Feed_feedId",
                        column: x => x.feedId,
                        principalTable: "Feed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeeds_Res_resId",
                        column: x => x.resId,
                        principalTable: "Res",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_feedId",
                table: "UserFeeds",
                column: "feedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_resId",
                table: "UserFeeds",
                column: "resId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeeds_userId",
                table: "UserFeeds",
                column: "userId");
        }
    }
}
