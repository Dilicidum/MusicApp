using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cf410b7-9e82-4a77-8908-1a212d94fd9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b83004-c8f7-4c16-b21c-2e4c6551dc86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbc9d93-a19b-4bac-a786-8e64d6817f86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85d007cd-c566-401d-8f71-64b42db483cc", "9ddaaab8-04ee-46fa-bb48-ca013f548a8b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92251986-d12a-434e-a2a4-5d293600bbdc", "5639037a-c478-457e-9f3d-0907a6bd0000", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18c871f6-e171-49a5-ad65-c4330e37d2dd", "14617ccd-beb9-46a4-a30c-854138adfd01", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c871f6-e171-49a5-ad65-c4330e37d2dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85d007cd-c566-401d-8f71-64b42db483cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92251986-d12a-434e-a2a4-5d293600bbdc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbc9d93-a19b-4bac-a786-8e64d6817f86", "149af3e4-1ab9-4b6f-a1de-3f193e1e3791", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79b83004-c8f7-4c16-b21c-2e4c6551dc86", "4a9a253f-72f9-4cd1-85b8-24963591f395", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cf410b7-9e82-4a77-8908-1a212d94fd9b", "f780723c-348e-4a6e-aae6-89849a234879", "User", "USER" });
        }
    }
}
