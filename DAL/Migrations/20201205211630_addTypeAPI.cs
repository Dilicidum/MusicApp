using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addTypeAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01ac7993-54c8-476f-a0e8-5d6ef539c70c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088156c1-22ae-427e-8de9-b3206d52aa85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5680a61d-3782-4861-bac9-8e1e88d3bbae");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ApiSettings",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ApiSettings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "088156c1-22ae-427e-8de9-b3206d52aa85", "692f6bc2-dd33-4635-90a4-4edac57e997f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5680a61d-3782-4861-bac9-8e1e88d3bbae", "def55932-4579-4a8c-afce-9d00bf6b6edb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01ac7993-54c8-476f-a0e8-5d6ef539c70c", "943b9c5a-3d80-4da8-818c-f099cad7b790", "User", "USER" });
        }
    }
}
