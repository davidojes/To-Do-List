using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class EditIsCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompeleted",
                table: "ToDoListItem");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ToDoListItem",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ToDoListItem",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ToDoListItem");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ToDoListItem",
                newName: "description");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompeleted",
                table: "ToDoListItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
