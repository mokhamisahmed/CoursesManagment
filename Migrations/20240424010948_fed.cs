using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class fed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    responseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFedbacks_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFedbacks_Feedbacks_feedbackId",
                        column: x => x.feedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFedbacks_Responses_responseId",
                        column: x => x.responseId,
                        principalTable: "Responses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

       

         

            migrationBuilder.CreateIndex(
                name: "IX_UserFedbacks_feedbackId",
                table: "UserFedbacks",
                column: "feedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFedbacks_responseId",
                table: "UserFedbacks",
                column: "responseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFedbacks_userId",
                table: "UserFedbacks",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "UserFedbacks");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
