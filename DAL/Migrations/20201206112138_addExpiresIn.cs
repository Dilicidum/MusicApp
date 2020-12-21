using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addExpiresIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35cbfc3f-8979-428f-949c-98dcbedeeb66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e239db3-ea28-4ca1-8788-69668961c952");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8779557-451a-44b0-8bd9-16a750a9579b");

            migrationBuilder.AddColumn<int>(
                name: "ExpiresIn",
                table: "ApiSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb39f618-168a-4164-8c14-2ceb4a8090ac", "54177949-fb7a-4ebc-a846-0bd5b6f78a32", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e88e5c59-788a-4064-a66d-430b8c0e375d", "23400bf8-a7e9-4919-80e3-a085439ffb81", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40d82912-496d-4821-86f3-c126f2f32e1c", "a8a413e6-751a-470f-aa11-3c8c385b9ac8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d82912-496d-4821-86f3-c126f2f32e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb39f618-168a-4164-8c14-2ceb4a8090ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e88e5c59-788a-4064-a66d-430b8c0e375d");

            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "ApiSettings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8779557-451a-44b0-8bd9-16a750a9579b", "f0f113f2-ddb4-485a-b423-a23cd79d0c2b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e239db3-ea28-4ca1-8788-69668961c952", "a2e7f071-826c-4ffc-b8b0-5ea89bcdaae0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35cbfc3f-8979-428f-949c-98dcbedeeb66", "4054cad9-4133-408e-bb85-4dace2ba096c", "User", "USER" });
        }
    }
}
