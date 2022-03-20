using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultCourse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CourseDefaultUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId2",
                table: "StudentPhoto");

            migrationBuilder.RenameColumn(
                name: "CourseId2",
                table: "StudentPhoto",
                newName: "DefaultCourseId");

            migrationBuilder.RenameColumn(
                name: "DefaultCoursesId",
                table: "DefaultUsers",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultUsers_DefaultCoursesId",
                table: "DefaultUsers",
                newName: "IX_DefaultUsers_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "DefaultCourseId", "DefaultUserId" });

            migrationBuilder.CreateTable(
                name: "DefaultCoursesDefaultUser",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCoursesDefaultUser", x => new { x.CoursesId, x.DefaultUsersId });
                    table.ForeignKey(
                        name: "FK_DefaultCoursesDefaultUser_DefaultCourses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "DefaultCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultCoursesDefaultUser_DefaultUsers_DefaultUsersId",
                        column: x => x.DefaultUsersId,
                        principalTable: "DefaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCoursesDefaultUser_DefaultUsersId",
                table: "DefaultCoursesDefaultUser",
                column: "DefaultUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultUsers_Courses_CourseId",
                table: "DefaultUsers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultUsers_Courses_CourseId",
                table: "DefaultUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Courses_CourseId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultCourses_DefaultCourseId",
                table: "StudentPhoto");

            migrationBuilder.DropTable(
                name: "DefaultCoursesDefaultUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto");

            migrationBuilder.RenameColumn(
                name: "DefaultCourseId",
                table: "StudentPhoto",
                newName: "CourseId2");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "DefaultUsers",
                newName: "DefaultCoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultUsers_CourseId",
                table: "DefaultUsers",
                newName: "IX_DefaultUsers_DefaultCoursesId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "CourseId", "DefaultUserId" });

            migrationBuilder.CreateTable(
                name: "CourseDefaultUser",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDefaultUser", x => new { x.CoursesId, x.DefaultUsersId });
                    table.ForeignKey(
                        name: "FK_CourseDefaultUser_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDefaultUser_DefaultUsers_DefaultUsersId",
                        column: x => x.DefaultUsersId,
                        principalTable: "DefaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId2",
                table: "StudentPhoto",
                column: "CourseId2");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDefaultUser_DefaultUsersId",
                table: "CourseDefaultUser",
                column: "DefaultUsersId");

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
    }
}
