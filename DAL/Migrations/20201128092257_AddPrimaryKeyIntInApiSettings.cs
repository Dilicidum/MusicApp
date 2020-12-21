using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddPrimaryKeyIntInApiSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiSettings",
                table: "ApiSettings");

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

            migrationBuilder.AlterColumn<string>(
                name: "ApiName",
                table: "ApiSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApiSettings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiSettings",
                table: "ApiSettings",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiSettings",
                table: "ApiSettings");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApiSettings");

            migrationBuilder.AlterColumn<string>(
                name: "ApiName",
                table: "ApiSettings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiSettings",
                table: "ApiSettings",
                column: "ApiName");

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
    }
}
