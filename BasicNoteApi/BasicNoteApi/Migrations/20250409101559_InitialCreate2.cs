using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicNoteApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteText",
                table: "Notes",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Notes",
                newName: "NoteText");
        }
    }
}
