using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuliChat.Entities.Migrations
{
    public partial class deleteUserChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserServer_AspNetUsers_UserId",
                table: "UserServer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserServer_Servers_ServerId",
                table: "UserServer");

            migrationBuilder.DropTable(
                name: "UserChannel");

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

            migrationBuilder.CreateTable(
                name: "UserChannel",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChannel", x => new { x.UserId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_UserChannel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChannel_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChannel_ChannelId",
                table: "UserChannel",
                column: "ChannelId");

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
