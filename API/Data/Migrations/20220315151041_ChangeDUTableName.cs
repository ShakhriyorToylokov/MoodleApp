using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangeDUTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_DefaultUser_DefaultUserId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultUser",
                table: "DefaultUser");

            migrationBuilder.RenameTable(
                name: "DefaultUser",
                newName: "DefaultUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultUsers",
                table: "DefaultUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_DefaultUsers_DefaultUserId",
                table: "Photos",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_DefaultUsers_DefaultUserId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultUsers",
                table: "DefaultUsers");

            migrationBuilder.RenameTable(
                name: "DefaultUsers",
                newName: "DefaultUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultUser",
                table: "DefaultUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_DefaultUser_DefaultUserId",
                table: "Photos",
                column: "DefaultUserId",
                principalTable: "DefaultUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
