using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class _3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1-admin",
                column: "ConcurrencyStamp",
                value: "3a3c7ae9-f188-4bb1-8faa-7d0ebd8f31b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2-doctor",
                column: "ConcurrencyStamp",
                value: "842d3da0-f6db-404f-8bed-0261e0757d7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3-patient",
                column: "ConcurrencyStamp",
                value: "2c362310-c364-4ba3-b6cd-2ecc813f46e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e465538-fa20-40b8-8de3-95c07c72e8e6", "AQAAAAEAACcQAAAAEI4FuR7NlZXbRi0We3Uap5A9Sk4gPfWqhmMrg2mWcT4H83asqdes3gqzIqHu1i1QEg==", "f69ad1d6-2611-4144-a81b-2485a124bbb5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1-admin",
                column: "ConcurrencyStamp",
                value: "b99596f6-6703-477a-9194-7620573c9be7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2-doctor",
                column: "ConcurrencyStamp",
                value: "e7769cfa-e837-4b11-83ad-73e24f6df4a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3-patient",
                column: "ConcurrencyStamp",
                value: "0e72c96f-47df-4c05-b62e-e3d8a6c6b8ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0677852-a1a2-414f-a2e4-334b0a16a6b8", "AQAAAAEAACcQAAAAENf1+b7CVcjb7eIMTZoCvthJ2wUhS76j52rCodjxjIjY7TuE2JgbLXEVPquCVY/Jhw==", "888b94fc-e2e8-4760-b62a-e883e317b7dd" });
        }
    }
}
