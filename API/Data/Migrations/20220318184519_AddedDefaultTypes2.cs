using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId1",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_StudentId1",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_StudentId1",
                table: "StudentPhoto",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Students_StudentId1",
                table: "StudentPhoto",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
