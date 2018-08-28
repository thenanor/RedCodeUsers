using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class renamingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Users",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
