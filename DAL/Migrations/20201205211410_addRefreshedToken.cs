using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addRefreshedToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "016dc8d4-96d1-4ddb-b768-c27dbb262cc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19c360ef-81c2-43b9-b914-cbaf2f0b52d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd74b91d-1a58-4183-accd-cf29b7013141");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "ApiSettings",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "ApiSettings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19c360ef-81c2-43b9-b914-cbaf2f0b52d4", "4ea2d350-02a5-4b23-a7d3-6acf2d707ac1", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "016dc8d4-96d1-4ddb-b768-c27dbb262cc6", "e2a7ff14-7b89-49b6-b77b-c4e500c702df", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd74b91d-1a58-4183-accd-cf29b7013141", "22735724-351f-4260-8bd7-9ed4d2f45c2a", "User", "USER" });
        }
    }
}
