using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddPathToByteImageAvatars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e4c672-7ad7-41ee-87ba-62e7ed89f3ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb196fe-5bdf-4d75-ac54-60508321cec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed26eb8c-7a54-4073-94e6-127c6717f5d6");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "PathByteImage",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathImageFile",
                table: "Images",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58f4f735-63ae-4a0c-87de-83ecb730de44", "0540b9c8-a086-4b16-9c74-317a1ebce19d", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43130d49-372d-4e58-88fe-307aee3fec7b", "50e222a0-3462-4493-8aa0-565870dde302", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94a76622-0321-4325-a2d0-02ffdcbaf5a1", "a7433f1c-84e9-418d-a236-3639d0187399", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43130d49-372d-4e58-88fe-307aee3fec7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58f4f735-63ae-4a0c-87de-83ecb730de44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a76622-0321-4325-a2d0-02ffdcbaf5a1");

            migrationBuilder.DropColumn(
                name: "PathByteImage",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PathImageFile",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcb196fe-5bdf-4d75-ac54-60508321cec9", "57fb34b3-c6ee-4e3d-9de6-aed6d85e9329", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77e4c672-7ad7-41ee-87ba-62e7ed89f3ca", "007d76ef-e034-40fd-a116-d8a2ec4c61f6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed26eb8c-7a54-4073-94e6-127c6717f5d6", "ceea8e03-c83b-4b0d-9502-4e8ed7cd2fbf", "User", "USER" });
        }
    }
}
