using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangeStudentPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Students_StudentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_StudentId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Photos");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StudentPhoto",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_StudentId",
                table: "Photos",
                column: "StudentId");

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
