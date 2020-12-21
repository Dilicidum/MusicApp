using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeTypeRefreshedToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239389c3-bc76-4dfd-abc0-21174860e990");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "983bff76-b0a1-4675-beac-d532b8821466");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff9e8624-e220-4626-a8f1-0ce33e89c87d");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ApiSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ApiSettings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff9e8624-e220-4626-a8f1-0ce33e89c87d", "0a2be14d-c9fb-4336-9050-1267ba36c56c", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "983bff76-b0a1-4675-beac-d532b8821466", "462af177-fe70-4081-ae19-d223f2d97f07", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "239389c3-bc76-4dfd-abc0-21174860e990", "9ab441a1-5e97-4b5c-af24-9418c1d00c3f", "User", "USER" });
        }
    }
}
