using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addLikesAndDislikesToSongEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbc9d93-a19b-4bac-a786-8e64d6817f86", "149af3e4-1ab9-4b6f-a1de-3f193e1e3791", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79b83004-c8f7-4c16-b21c-2e4c6551dc86", "4a9a253f-72f9-4cd1-85b8-24963591f395", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cf410b7-9e82-4a77-8908-1a212d94fd9b", "f780723c-348e-4a6e-aae6-89849a234879", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cf410b7-9e82-4a77-8908-1a212d94fd9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b83004-c8f7-4c16-b21c-2e4c6551dc86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbc9d93-a19b-4bac-a786-8e64d6817f86");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Songs");

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
    }
}
