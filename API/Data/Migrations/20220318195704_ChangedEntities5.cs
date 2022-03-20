using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangedEntities5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCourses_Teachers_TeacherId",
                table: "DefaultCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
