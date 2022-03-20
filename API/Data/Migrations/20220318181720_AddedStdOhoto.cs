using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedStdOhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "StudentPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPhoto_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto",
                column: "StudentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "StudentPhoto");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Teachers_TeacherId",
                table: "Photos",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
