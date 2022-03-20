using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class DefaultUserTableDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_DefaultUsers_DefaultUserId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "DefaultUsers");

            migrationBuilder.DropIndex(
                name: "IX_Photos_DefaultUserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_DefaultPhoto_DefaultUserId",
                table: "DefaultPhoto");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "DefaultPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultUserId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUserId",
                table: "DefaultPhoto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DefaultUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    StdNum = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_DefaultUserId",
                table: "Photos",
                column: "DefaultUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPhoto_DefaultUserId",
                table: "DefaultPhoto",
                column: "DefaultUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPhoto_DefaultUsers_DefaultUserId",
                table: "DefaultPhoto",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_DefaultUsers_DefaultUserId",
                table: "Photos",
                column: "DefaultUserId",
                principalTable: "DefaultUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
