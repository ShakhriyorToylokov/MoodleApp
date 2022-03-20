using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedTeacherIdToDP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPhoto_TeacherId",
                table: "DefaultPhoto",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_Teachers_TeacherId",
                table: "DefaultPhoto",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_Teachers_TeacherId",
                table: "DefaultPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_DefaultPhoto_TeacherId",
                table: "DefaultPhoto");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "DefaultPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_Students_StudentId",
                table: "DefaultPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
