using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DefaultPhotoTableDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Photos_StudentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_StudentId",
                table: "Photos",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_StudentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TeacherId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "DefaultPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultPhoto_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultPhoto_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
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
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPhoto_StudentId",
                table: "DefaultPhoto",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPhoto_TeacherId",
                table: "DefaultPhoto",
                column: "TeacherId",
                unique: true);
        }
    }
}
