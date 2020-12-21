using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeNameOfSongEntityProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PathToSong",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToSongSerialized",
                table: "Songs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d004565d-c40c-428c-8182-73a7fec82100", "77bcbe90-f8a8-4543-93ce-b74ca94b548c", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78c91f8b-4aa1-4363-ba5b-d9903bcbd63b", "3eaf8142-bfd7-445c-9b02-565083d14cee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7e925d1-0974-4bb7-99da-0e0dfaf6317d", "5440d4cd-2922-4511-b3de-ddf79e2c4906", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78c91f8b-4aa1-4363-ba5b-d9903bcbd63b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d004565d-c40c-428c-8182-73a7fec82100");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e925d1-0974-4bb7-99da-0e0dfaf6317d");

            migrationBuilder.DropColumn(
                name: "PathToSong",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PathToSongSerialized",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "PathByteSong",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathByteSongSerialized",
                table: "Songs",
                type: "nvarchar(max)",
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
    }
}
