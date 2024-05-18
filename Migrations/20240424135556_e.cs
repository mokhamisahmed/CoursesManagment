using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityItI.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name:"Feed"
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Feed",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   
                   feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   response = table.Column<string>(type: "nvarchar(max)", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Res", x => x.Id);
                   
               });

       
        }


    }
}
