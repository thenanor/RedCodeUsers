using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactAddress", "ContactPhone", "Email", "FullName", "Gender", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "78 Cedar St. Burke, VA 22015", "076485765", "john.smith@gmail.com", "John Smith", "M", new DateTime(2018, 8, 14, 11, 17, 36, 48, DateTimeKind.Local) },
                    { 2, "920 Thorne Avenue Elk River, MN 55330", "054346876", "elidia.lowrey@gmail.com", "Elidia Lowrey", "F", new DateTime(2018, 8, 14, 11, 17, 36, 52, DateTimeKind.Local) },
                    { 3, "9544 White St. Glen Burnie, MD 21060", "023678398", "linwood.bartz@gmail.com", "Linwood Bartz", "M", new DateTime(2018, 8, 16, 11, 17, 36, 52, DateTimeKind.Local) },
                    { 4, "493 Bay Meadows St. Evans, GA 30809", "0745678765", "reva.kunkel@gmail.com", "Reva Kunkel", "F", new DateTime(2018, 8, 18, 11, 17, 36, 52, DateTimeKind.Local) },
                    { 5, "7827 Miller Street Bedford, OH 44146", "098543234", "marna.lampman@gmail.com", "Marna Lampman", "F", new DateTime(2018, 8, 21, 11, 17, 36, 52, DateTimeKind.Local) },
                    { 6, "8328 Grandrose St. Crystal Lake, IL 60014", "087098565", "marcos.tittle@gmail.com", "Marcos Tittle", "M", new DateTime(2018, 8, 21, 11, 17, 36, 52, DateTimeKind.Local) },
                    { 7, "63 Fawn St. Wantagh, NY 11793", "088654456", "mia.smits@gmail.com", "Mia Smits", "F", new DateTime(2018, 8, 24, 11, 17, 36, 52, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "M");
        }
    }
}
