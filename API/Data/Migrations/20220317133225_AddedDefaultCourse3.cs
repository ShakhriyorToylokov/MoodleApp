using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultCourse3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_DefaultCourseId",
                table: "StudentPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultCourseId",
                table: "StudentPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultCoursesId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "CourseId", "DefaultUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_DefaultCoursesId",
                table: "StudentPhoto",
                column: "DefaultCoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_DefaultCoursesId",
                table: "StudentPhoto",
                column: "DefaultCoursesId",
                principalTable: "DefaultCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_DefaultCoursesId",
                table: "StudentPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_DefaultCoursesId",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultCoursesId",
                table: "StudentPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DefaultCourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "DefaultCourseId", "DefaultUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_DefaultCourseId",
                table: "StudentPhoto",
                column: "DefaultCourseId",
                principalTable: "DefaultCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
