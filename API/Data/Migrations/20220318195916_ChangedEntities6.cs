using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangedEntities6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCourses_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "DefaultCourses");

            migrationBuilder.CreateTable(
                name: "DefaultCoursesTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCoursesTeacher", x => new { x.CoursesId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_DefaultCoursesTeacher_DefaultCourses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "DefaultCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultCoursesTeacher_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCoursesTeacher_TeacherId",
                table: "DefaultCoursesTeacher",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultCoursesTeacher");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "DefaultCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCourses_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
