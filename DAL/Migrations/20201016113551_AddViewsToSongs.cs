using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddViewsToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1041717-0b05-4410-9c56-374d39c8bd1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1b16d14-521b-4a49-874e-7375038645cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9a273b0-09a7-4658-b935-fc04dc2b2129");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9324ad72-3ed3-4d7b-8938-a97adbcc66dc", "07e72d3a-d7f5-4a8b-8570-8229cdbc355c", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f48c0dc-8c43-4c24-aecc-ec86306fe9f2", "e3ca6ce2-6ed3-4633-983e-d3f18f67099a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abc3cbae-a63b-47e6-96f0-380a63b6dc40", "ab5aa32d-3530-489c-909f-014b29e49cf7", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f48c0dc-8c43-4c24-aecc-ec86306fe9f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9324ad72-3ed3-4d7b-8938-a97adbcc66dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abc3cbae-a63b-47e6-96f0-380a63b6dc40");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Songs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1b16d14-521b-4a49-874e-7375038645cd", "68e5f8d3-dedb-480b-b15d-21ce4bf03c79", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1041717-0b05-4410-9c56-374d39c8bd1d", "ee16b139-6c5b-4f5b-bc39-bcf99b46987e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9a273b0-09a7-4658-b935-fc04dc2b2129", "f60e81cb-8fe3-40b0-9ca8-679491ddaca2", "User", "USER" });
        }
    }
}
