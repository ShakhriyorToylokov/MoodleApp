using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangeEntities4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultUsers_Courses_CourseId",
                table: "DefaultUsers");

            migrationBuilder.DropTable(
                name: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_DefaultUsers_CourseId",
                table: "DefaultUsers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "DefaultUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "DefaultUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultCoursesId = table.Column<int>(type: "INTEGER", nullable: true),
                    DefaultUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPhoto_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPhoto_DefaultCourses_DefaultCoursesId",
                        column: x => x.DefaultCoursesId,
                        principalTable: "DefaultCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                        column: x => x.DefaultUserId,
                        principalTable: "DefaultUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPhoto_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultUsers_CourseId",
                table: "DefaultUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_CourseId",
                table: "StudentPhoto",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_DefaultCoursesId",
                table: "StudentPhoto",
                column: "DefaultCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_DefaultUserId",
                table: "StudentPhoto",
                column: "DefaultUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultUsers_Courses_CourseId",
                table: "DefaultUsers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
