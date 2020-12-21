using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddForeignKeyUserIdToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6415b5dc-501a-4dd3-98ef-8e950cf53fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c89a0a05-fa57-4bee-99d5-a63fe7e2dfb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e374814d-5218-4499-9b5d-c3be5f022aa7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b344feb0-f33b-45da-ae54-b029bcfd8cb2", "79272954-7dfd-4912-8ad7-bb5ce4af806f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8432d9b-d2c8-4644-98a9-2d4b9e8821a7", "84d76cf3-e4fe-449a-a892-e7627572f4cd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39fabe37-6d64-4127-8a4d-ac16c59cb8e2", "3085e750-bbd4-4c54-96e9-ec76f1ac9bf1", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39fabe37-6d64-4127-8a4d-ac16c59cb8e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b344feb0-f33b-45da-ae54-b029bcfd8cb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8432d9b-d2c8-4644-98a9-2d4b9e8821a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6415b5dc-501a-4dd3-98ef-8e950cf53fea", "9a09e7ba-aa9c-47a2-9014-df6224f5724a", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e374814d-5218-4499-9b5d-c3be5f022aa7", "218f6786-6591-4d67-a206-95c0f8c11ba9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c89a0a05-fa57-4bee-99d5-a63fe7e2dfb1", "d421e69e-33e4-439f-8492-11d5657da0aa", "User", "USER" });
        }
    }
}
