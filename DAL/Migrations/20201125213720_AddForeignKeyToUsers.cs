using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddForeignKeyToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e277ced-fd19-49b0-afb5-7f0e0f13a6c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2b0b2d3-55ba-4e91-80b8-0fa69935bf50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c059d562-3f64-4f4c-adf8-c4b2a31427d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51f37127-d6ab-4aeb-9204-e6d8168072d3", "d4f87401-2843-4593-bc39-129feb2dc043", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4cb3b7e-0e5d-4b04-963d-618635e5761b", "5ded6d60-81fc-4abd-9f83-bd9c47a1e8c5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7b0108b-6cbd-4cb3-bfcc-22559bfbe120", "35983032-e1d3-4d0a-b84a-a4c9c23f506e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51f37127-d6ab-4aeb-9204-e6d8168072d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b0108b-6cbd-4cb3-bfcc-22559bfbe120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4cb3b7e-0e5d-4b04-963d-618635e5761b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e277ced-fd19-49b0-afb5-7f0e0f13a6c1", "ae29d527-94d2-4b1a-8067-5c29dd53f89d", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2b0b2d3-55ba-4e91-80b8-0fa69935bf50", "4790b69d-d796-4541-a0a9-80eb889553c8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c059d562-3f64-4f4c-adf8-c4b2a31427d7", "54f1316b-a86b-4afd-baa1-cf3df8f47b76", "User", "USER" });
        }
    }
}
