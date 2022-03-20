using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId2",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultCoursesId",
                table: "DefaultUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "CourseId", "DefaultUserId" });

            migrationBuilder.CreateTable(
                name: "DefaultCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfCourse = table.Column<string>(type: "TEXT", nullable: true),
                    CourseCode = table.Column<string>(type: "TEXT", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCourses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId2",
                table: "StudentPhoto",
                column: "CourseId2");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultUsers_DefaultCoursesId",
                table: "DefaultUsers",
                column: "DefaultCoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultUsers_DefaultCourses_DefaultCoursesId",
                table: "DefaultUsers",
                column: "DefaultCoursesId",
                principalTable: "DefaultCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId2",
                table: "StudentPhoto",
                column: "CourseId2",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_CourseId",
                table: "StudentPhoto",
                column: "CourseId",
                principalTable: "DefaultCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultUsers_DefaultCourses_DefaultCoursesId",
                table: "DefaultUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId2",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropTable(
                name: "DefaultCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId2",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_DefaultUsers_DefaultCoursesId",
                table: "DefaultUsers");

            migrationBuilder.DropColumn(
                name: "CourseId2",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultCoursesId",
                table: "DefaultUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                column: "Id");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
