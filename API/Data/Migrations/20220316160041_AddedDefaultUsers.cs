using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StdPhotos_Students_StudentId",
                table: "StdPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StdPhotos",
                table: "StdPhotos");

            migrationBuilder.RenameTable(
                name: "StdPhotos",
                newName: "StudentPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_StdPhotos_StudentId",
                table: "StudentPhoto",
                newName: "IX_StudentPhoto_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DefaultUserId",
                table: "StudentPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DefaultUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    StdNum = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoto_DefaultUserId",
                table: "StudentPhoto",
                column: "DefaultUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_DefaultUsers_DefaultUserId",
                table: "StudentPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhoto_Students_StudentId",
                table: "StudentPhoto");

            migrationBuilder.DropTable(
                name: "DefaultUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPhoto",
                table: "StudentPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StudentPhoto_DefaultUserId",
                table: "StudentPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "StudentPhoto");

            migrationBuilder.RenameTable(
                name: "StudentPhoto",
                newName: "StdPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_StudentPhoto_StudentId",
                table: "StdPhotos",
                newName: "IX_StdPhotos_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StdPhotos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StdPhotos",
                table: "StdPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StdPhotos_Students_StudentId",
                table: "StdPhotos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
