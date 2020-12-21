using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c0ec1a2-89f7-4491-9241-0f87130319bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf96c34c-72da-43c0-8449-bda797c6554b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee0bb307-a7a2-4513-82f1-c8307bfcc030");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1139c0f-a185-4923-b121-d2d57ac3b530", "d31ce97a-6f36-4da3-a614-a8b250b7ce72", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad1a9856-4cfb-4d0a-bc24-9433e08198c0", "0c99d9f6-8a7a-4fd0-8d94-08cfeb212a1f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9d1be61-e4b9-411b-9533-378e9118ea18", "7cf383d5-ffb5-40e0-8a47-9d85cca29edb", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad1a9856-4cfb-4d0a-bc24-9433e08198c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1139c0f-a185-4923-b121-d2d57ac3b530");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9d1be61-e4b9-411b-9533-378e9118ea18");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c0ec1a2-89f7-4491-9241-0f87130319bf", "f7b80572-6b68-4e2c-ab11-f290aa631e14", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf96c34c-72da-43c0-8449-bda797c6554b", "e5b2dfcf-4242-4349-b43a-0008aadbc1fa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee0bb307-a7a2-4513-82f1-c8307bfcc030", "2b655c8e-0996-4556-b7fc-5ef28db6e8f7", "User", "USER" });
        }
    }
}
