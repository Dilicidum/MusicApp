using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addUploadDateApiSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ef92ec-8acf-4b48-978c-1c1d143ea344");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c086cb-c9a2-48ea-ae36-cb6e5dcb2485");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42170861-4242-4f4f-8bb8-7c943a058caa");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBeingSet",
                table: "ApiSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateOfBeingSet",
                table: "ApiSettings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40c086cb-c9a2-48ea-ae36-cb6e5dcb2485", "a5a3224b-9a84-4b40-8730-f90112c2fce9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21ef92ec-8acf-4b48-978c-1c1d143ea344", "d961e149-36b2-458b-90f7-0f2aae68864c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42170861-4242-4f4f-8bb8-7c943a058caa", "06ab21a8-0d7c-41bc-8f16-fe7f35f9b495", "User", "USER" });
        }
    }
}
