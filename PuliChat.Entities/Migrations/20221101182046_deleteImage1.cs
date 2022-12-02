using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuliChat.Entities.Migrations
{
    public partial class deleteImage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "defaultServer.png");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "default.png");
        }
    }
}
