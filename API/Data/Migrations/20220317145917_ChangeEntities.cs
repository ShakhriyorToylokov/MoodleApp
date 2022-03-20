using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto");

            migrationBuilder.DropTable(
                name: "DefaultCoursesDefaultUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_StudentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "DefaultCoursesId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUserId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUserId",
                table: "DefaultCourses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DefaultCoursesId",
                table: "Students",
                column: "DefaultCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCourses_DefaultUserId",
                table: "DefaultCourses",
                column: "DefaultUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCourses_DefaultUsers_DefaultUserId",
                table: "DefaultCourses",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DefaultCourses_DefaultCoursesId",
                table: "Students",
                column: "DefaultCoursesId",
                principalTable: "DefaultCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCourses_DefaultUsers_DefaultUserId",
                table: "DefaultCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_DefaultCourses_DefaultCoursesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DefaultCoursesId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCourses_DefaultUserId",
                table: "DefaultCourses");

            migrationBuilder.DropColumn(
                name: "DefaultCoursesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "DefaultCourses");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUserId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Photos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                columns: new[] { "CourseId", "DefaultUserId" });

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
                name: "IX_Photos_StudentId",
                table: "Photos",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCoursesDefaultUser_DefaultUsersId",
                table: "DefaultCoursesDefaultUser",
                column: "DefaultUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
