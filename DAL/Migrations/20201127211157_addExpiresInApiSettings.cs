using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addExpiresInApiSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "233fa069-b79c-4a53-814c-5d48d65089f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98cecceb-76e5-4cc9-8bff-ce0768cdf5d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edfa1f48-6a92-4437-9522-54d61afe25f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b82f07d3-33c1-4d07-8420-d82e1d4a4b92", "f21c4eb0-215a-4312-bda6-efc749ac98a7", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2de8bc1-b22d-4141-be57-3d90551d4b81", "59ba3a15-870f-4d84-8acb-b1140710b7ff", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2cc1ef5-a8bb-466c-92d2-f3a966cb51f4", "76592c0c-10b2-4a90-bf74-afe169cbb711", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2cc1ef5-a8bb-466c-92d2-f3a966cb51f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b82f07d3-33c1-4d07-8420-d82e1d4a4b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2de8bc1-b22d-4141-be57-3d90551d4b81");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "233fa069-b79c-4a53-814c-5d48d65089f1", "d8bea2b3-3641-47da-b9ab-a54eafbaef30", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edfa1f48-6a92-4437-9522-54d61afe25f4", "0ae0519a-c485-46e8-b90a-80604d0ab0ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98cecceb-76e5-4cc9-8bff-ce0768cdf5d1", "424fa29e-8b6f-443d-accd-6c58484f3387", "User", "USER" });
        }
    }
}
