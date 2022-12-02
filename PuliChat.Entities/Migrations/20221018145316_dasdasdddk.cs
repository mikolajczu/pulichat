using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuliChat.Entities.Migrations
{
    public partial class dasdasdddk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UsersServers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersServers_UserId",
                table: "UsersServers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers");

            migrationBuilder.DropIndex(
                name: "IX_UsersServers_UserId",
                table: "UsersServers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersServers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersServers",
                table: "UsersServers",
                columns: new[] { "UserId", "ServerId" });
        }
    }
}
