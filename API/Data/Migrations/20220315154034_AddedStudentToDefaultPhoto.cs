using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedStudentToDefaultPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPhoto_StudentId",
                table: "DefaultPhoto",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto");

            migrationBuilder.DropIndex(
                name: "IX_DefaultPhoto_StudentId",
                table: "DefaultPhoto");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "DefaultPhoto");
        }
    }
}
