using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddForeignKeyPublicIdToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51f37127-d6ab-4aeb-9204-e6d8168072d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b0108b-6cbd-4cb3-bfcc-22559bfbe120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4cb3b7e-0e5d-4b04-963d-618635e5761b");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Songs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6415b5dc-501a-4dd3-98ef-8e950cf53fea", "9a09e7ba-aa9c-47a2-9014-df6224f5724a", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e374814d-5218-4499-9b5d-c3be5f022aa7", "218f6786-6591-4d67-a206-95c0f8c11ba9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c89a0a05-fa57-4bee-99d5-a63fe7e2dfb1", "d421e69e-33e4-439f-8492-11d5657da0aa", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6415b5dc-501a-4dd3-98ef-8e950cf53fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c89a0a05-fa57-4bee-99d5-a63fe7e2dfb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e374814d-5218-4499-9b5d-c3be5f022aa7");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Songs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51f37127-d6ab-4aeb-9204-e6d8168072d3", "d4f87401-2843-4593-bc39-129feb2dc043", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4cb3b7e-0e5d-4b04-963d-618635e5761b", "5ded6d60-81fc-4abd-9f83-bd9c47a1e8c5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7b0108b-6cbd-4cb3-bfcc-22559bfbe120", "35983032-e1d3-4d0a-b84a-a4c9c23f506e", "User", "USER" });
        }
    }
}
