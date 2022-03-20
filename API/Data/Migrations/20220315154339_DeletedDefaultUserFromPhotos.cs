using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DeletedDefaultUserFromPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUserId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUserId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
