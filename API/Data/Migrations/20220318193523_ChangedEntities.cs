using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CourseId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_StudentId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "DefaultCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DefaultUserTeacher",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultUserTeacher", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_DefaultUserTeacher_DefaultUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "DefaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultUserTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StudentId",
                table: "Teachers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCourses_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultUserTeacher_TeachersId",
                table: "DefaultUserTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Students_StudentId",
                table: "Teachers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Students_StudentId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "DefaultUserTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StudentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCourses_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "DefaultCourses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CourseId",
                table: "Photos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_StudentId",
                table: "Photos",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeachersId",
                table: "StudentTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
