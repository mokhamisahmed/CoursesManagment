using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "responseId",
                table: "Feed");

            migrationBuilder.AddColumn<Guid>(
                name: "feedId",
                table: "Res",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Feed",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Res_feedId",
                table: "Res",
                column: "feedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feed_AspNetUsers_userId",
                table: "Feed",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Res_Feed_feedId",
                table: "Res",
                column: "feedId",
                principalTable: "Feed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feed_AspNetUsers_userId",
                table: "Feed");

            migrationBuilder.DropForeignKey(
                name: "FK_Res_Feed_feedId",
                table: "Res");

            migrationBuilder.DropIndex(
                name: "IX_Res_feedId",
                table: "Res");

            migrationBuilder.DropColumn(
                name: "feedId",
                table: "Res");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Feed",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "responseId",
                table: "Feed",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
