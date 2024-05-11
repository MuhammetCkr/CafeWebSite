using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextWeb.Data.Migrations
{
    public partial class Deneme4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_AspNetUsers_UserId1",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserId1",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Pages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pages",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserId",
                table: "Pages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_AspNetUsers_UserId",
                table: "Pages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_AspNetUsers_UserId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserId",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Pages",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserId1",
                table: "Pages",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_AspNetUsers_UserId1",
                table: "Pages",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
