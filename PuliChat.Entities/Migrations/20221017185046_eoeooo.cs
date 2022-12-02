using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuliChat.Entities.Migrations
{
    public partial class eoeooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserServer_AspNetUsers_UserId",
                table: "UserServer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserServer_Servers_ServerId",
                table: "UserServer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserServer",
                table: "UserServer");

            migrationBuilder.RenameTable(
                name: "UserServer",
                newName: "UsersServers");

            migrationBuilder.RenameIndex(
                name: "IX_UserServer_ServerId",
                table: "UsersServers",
                newName: "IX_UsersServers_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers",
                columns: new[] { "UserId", "ServerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServers_AspNetUsers_UserId",
                table: "UsersServers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServers_Servers_ServerId",
                table: "UsersServers",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersServers_AspNetUsers_UserId",
                table: "UsersServers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersServers_Servers_ServerId",
                table: "UsersServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers");

            migrationBuilder.RenameTable(
                name: "UsersServers",
                newName: "UserServer");

            migrationBuilder.RenameIndex(
                name: "IX_UsersServers_ServerId",
                table: "UserServer",
                newName: "IX_UserServer_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserServer",
                table: "UserServer",
                columns: new[] { "UserId", "ServerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserServer_AspNetUsers_UserId",
                table: "UserServer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserServer_Servers_ServerId",
                table: "UserServer",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
