using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
  public partial class DropUnusedColumns : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
           name: "PhoneNumber",
           table: "AspNetUsers");

      migrationBuilder.DropColumn(
           name: "PhoneNumberConfirmed",
           table: "AspNetUsers");

      migrationBuilder.DropColumn(
           name: "LockoutEnd",
           table: "AspNetUsers");

      migrationBuilder.DropColumn(
           name: "LockoutEnabled",
           table: "AspNetUsers");

      migrationBuilder.DropColumn(
           name: "AccessFailedCount",
           table: "AspNetUsers");

      migrationBuilder.DropColumn(
           name: "TwoFactorEnabled",
           table: "AspNetUsers");


    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
