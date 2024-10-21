using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "a642d1c5-3908-45d6-8420-2d3221c3ce3e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c3c1dde9-983e-43d4-b627-c0e04e511d70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b861c1e-f7a0-4995-8632-27e670fa37ee", "AQAAAAEAACcQAAAAEJCpSBayuZYDseMtP3mB5tCdUTPYGbYG8tLUk8LEdhs/6cow6jp4syaxKOMl2MCT9Q==", "c3e8a88d-e0ef-44ed-9308-e62fe158495e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "c92e9d8b-f4d6-4f0d-a63d-80ef462cdbde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "415a48b5-e371-417f-8290-f41747c5b49e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05630597-84fd-4438-8dc0-281c1925b78a", "AQAAAAEAACcQAAAAEGW2QJ0EtLcO/AH0DkcqF/ozmFZsoyyZQ/tQaFT48hAhAejxRsgQhToGsJjZyt+OpQ==", "6fa0109b-9322-46d0-a96f-9457a0434b0c" });
        }
    }
}
