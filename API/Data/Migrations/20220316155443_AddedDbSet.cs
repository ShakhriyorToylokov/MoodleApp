using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.RenameTable(
                name: "StudentPhoto",
                newName: "StdPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StdPhotos",
                newName: "IX_StdPhotos_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StdPhotos",
                table: "StdPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StdPhotos_Students_StudentId",
                table: "StdPhotos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StdPhotos_Students_StudentId",
                table: "StdPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StdPhotos",
                table: "StdPhotos");

            migrationBuilder.RenameTable(
                name: "StdPhotos",
                newName: "StudentPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_StdPhotos_StudentId",
                table: "StudentPhoto",
                newName: "IX_StudentPhoto_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
