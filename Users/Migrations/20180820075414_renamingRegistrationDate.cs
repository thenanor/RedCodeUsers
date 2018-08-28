using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class renamingRegistrationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "Users",
                newName: "RegistrationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Users",
                newName: "RegisteredDate");
        }
    }
}
