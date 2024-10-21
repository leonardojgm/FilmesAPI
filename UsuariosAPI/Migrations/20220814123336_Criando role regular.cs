using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "415a48b5-e371-417f-8290-f41747c5b49e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "c92e9d8b-f4d6-4f0d-a63d-80ef462cdbde", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05630597-84fd-4438-8dc0-281c1925b78a", "AQAAAAEAACcQAAAAEGW2QJ0EtLcO/AH0DkcqF/ozmFZsoyyZQ/tQaFT48hAhAejxRsgQhToGsJjZyt+OpQ==", "6fa0109b-9322-46d0-a96f-9457a0434b0c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "297596ef-2b58-4094-902c-e287cdfbd5cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc236958-8b7b-44e2-97e2-86dce83962ad", "AQAAAAEAACcQAAAAEJHYWrBFvZIovyvxrIVyXhRErz0ojlE5Z43qlg+HEUpMu9jzLL2u7T6aDX7Dt1WmsQ==", "c584aeb1-79b5-45ec-9e96-97232d03adee" });
        }
    }
}
