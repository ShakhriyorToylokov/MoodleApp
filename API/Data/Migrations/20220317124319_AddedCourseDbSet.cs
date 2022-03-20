using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedCourseDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_CourseId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CourseId",
                table: "Photos",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CourseId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentPhoto");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CourseId",
                table: "Photos",
                column: "CourseId",
                unique: true);
        }
    }
}
