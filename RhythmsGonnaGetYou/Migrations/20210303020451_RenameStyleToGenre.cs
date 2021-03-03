using Microsoft.EntityFrameworkCore.Migrations;

namespace RhythmsGonnaGetYou.Migrations
{
    public partial class RenameStyleToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Style",
                table: "Bands",
                newName: "Genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Bands",
                newName: "Style");
        }
    }
}
