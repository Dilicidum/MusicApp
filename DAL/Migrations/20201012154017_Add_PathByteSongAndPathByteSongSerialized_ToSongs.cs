using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Add_PathByteSongAndPathByteSongSerialized_ToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fd3de8c-9736-42da-8545-16e6885a8534");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6ef4560-10a4-4142-8cf4-ab81dfc20681");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df6c842c-8fd1-47aa-a14b-287f10ddf540");

            migrationBuilder.AddColumn<string>(
                name: "PathByteSong",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathByteSongSerialized",
                table: "Songs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26d76afa-74ea-4861-9617-509a43d09b63", "f2b307dd-1067-4ab3-b13d-a8436612e4c2", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e011f9b-9fba-4196-b1e7-eb812115f0b4", "7bb4758a-6e69-493a-a9ba-17dd9e6c3c45", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "829b86bf-62bb-4ad6-8fe1-2182bf6dad68", "b45b58ba-ea00-4252-be9a-9b065046ab47", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d76afa-74ea-4861-9617-509a43d09b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e011f9b-9fba-4196-b1e7-eb812115f0b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829b86bf-62bb-4ad6-8fe1-2182bf6dad68");

            migrationBuilder.DropColumn(
                name: "PathByteSong",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PathByteSongSerialized",
                table: "Songs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fd3de8c-9736-42da-8545-16e6885a8534", "9099be84-54ec-4ebe-a86c-e29d64f38efc", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df6c842c-8fd1-47aa-a14b-287f10ddf540", "f76ad8c9-fd0e-4610-a687-23972237cf38", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6ef4560-10a4-4142-8cf4-ab81dfc20681", "8de58526-4176-40ca-be0c-db3460e613e3", "User", "USER" });
        }
    }
}
