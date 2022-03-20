using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DeletedStudentsAndTeachersRelationship4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "TeacherPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_TeacherId",
                table: "TeacherPhotos",
                newName: "IX_TeacherPhotos_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherPhotos",
                table: "TeacherPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPhotos_Teachers_TeacherId",
                table: "TeacherPhotos",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPhotos_Teachers_TeacherId",
                table: "TeacherPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherPhotos",
                table: "TeacherPhotos");

            migrationBuilder.RenameTable(
                name: "TeacherPhotos",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPhotos_TeacherId",
                table: "Photos",
                newName: "IX_Photos_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
