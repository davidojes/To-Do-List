using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
  public partial class RemoveEmailConfirmedColumn : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(name: "EmailConfirmed", table: "AspNetUsers");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
