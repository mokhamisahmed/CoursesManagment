using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class us : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Res");

            migrationBuilder.AddColumn<string>(
                name: "response",
                table: "Feed",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "response",
                table: "Feed");

            migrationBuilder.CreateTable(
                name: "Res",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Res", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Res_Feed_feedId",
                        column: x => x.feedId,
                        principalTable: "Feed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Res_feedId",
                table: "Res",
                column: "feedId");
        }
    }
}
