using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class SeedUserInterests : Migration
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
                table: "UserInterests",
                columns: new[] { "UserId", "InterestId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 7 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "M", new DateTime(2018, 8, 14, 11, 18, 57, 440, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "F", new DateTime(2018, 8, 14, 11, 18, 57, 443, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "M", new DateTime(2018, 8, 16, 11, 18, 57, 443, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "F", new DateTime(2018, 8, 18, 11, 18, 57, 443, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "F", new DateTime(2018, 8, 21, 11, 18, 57, 443, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "M", new DateTime(2018, 8, 21, 11, 18, 57, 443, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { "F", new DateTime(2018, 8, 24, 11, 18, 57, 443, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "M");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 14, 11, 17, 36, 48, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 14, 11, 17, 36, 52, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 16, 11, 17, 36, 52, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 18, 11, 17, 36, 52, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 21, 11, 17, 36, 52, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 21, 11, 17, 36, 52, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Gender", "RegistrationDate" },
                values: new object[] { null, new DateTime(2018, 8, 24, 11, 17, 36, 52, DateTimeKind.Local) });
        }
    }
}
