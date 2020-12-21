using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddCloudSaveImagesId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PathByteImage",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PathImageFile",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Images",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e04b4214-62b9-4f47-85d7-9b8c19dc02ca", "5ee6e5f8-9586-4721-b3a7-0c1f79e701ba", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1c3f776-9bfe-48d6-810f-ecc87d637a1e", "c1c4754f-dd7b-4bcc-9697-22ff354b07eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d670d4d3-6840-42bf-b633-6cfe1ad4a653", "31f5fb10-587d-4d2c-918a-a722cad93652", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c3f776-9bfe-48d6-810f-ecc87d637a1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d670d4d3-6840-42bf-b633-6cfe1ad4a653");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e04b4214-62b9-4f47-85d7-9b8c19dc02ca");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "PathByteImage",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathImageFile",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
