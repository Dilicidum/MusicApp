using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddApiSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApiSettings",
                columns: table => new
                {
                    ApiName = table.Column<string>(nullable: false),
                    Acess_Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiSettings", x => x.ApiName);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiSettings");

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
    }
}
