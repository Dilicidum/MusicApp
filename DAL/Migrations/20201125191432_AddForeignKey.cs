using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c3f776-9bfe-48d6-810f-ecc87d637a1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d670d4d3-6840-42bf-b633-6cfe1ad4a653");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e04b4214-62b9-4f47-85d7-9b8c19dc02ca");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e04b4214-62b9-4f47-85d7-9b8c19dc02ca", "5ee6e5f8-9586-4721-b3a7-0c1f79e701ba", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1c3f776-9bfe-48d6-810f-ecc87d637a1e", "c1c4754f-dd7b-4bcc-9697-22ff354b07eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d670d4d3-6840-42bf-b633-6cfe1ad4a653", "31f5fb10-587d-4d2c-918a-a722cad93652", "User", "USER" });
        }
    }
}
