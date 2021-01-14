using Microsoft.EntityFrameworkCore.Migrations;

namespace PresenileNotes.Entity.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Categories");
        }
    }
}
