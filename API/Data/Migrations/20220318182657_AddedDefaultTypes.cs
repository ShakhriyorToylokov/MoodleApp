using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto");

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

            migrationBuilder.CreateTable(
                name: "DefaultUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    StdNum = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultCoursesDefaultUser",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCoursesDefaultUser", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_DefaultCoursesDefaultUser_DefaultCourses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "DefaultCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultCoursesDefaultUser_DefaultUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "DefaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCoursesDefaultUser_StudentsId",
                table: "DefaultCoursesDefaultUser",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropTable(
                name: "DefaultCoursesDefaultUser");

            migrationBuilder.DropTable(
                name: "DefaultCourses");

            migrationBuilder.DropTable(
                name: "DefaultUsers");

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
