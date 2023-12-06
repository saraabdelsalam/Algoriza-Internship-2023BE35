using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class RequestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Requests",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "57bf7473-dc58-4174-b7c8-2940f63a80d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "aac38f6f-e5f1-4f0a-bcd0-25056359bcf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "0495c067-2f9e-4764-b204-866c435262e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "150e6dbe-c2b4-4bfd-8628-49b35720c498", "AQAAAAEAACcQAAAAEOZhTxW+fcAluCT7bwZ4VNJfa3LdLHQhwY/VFgWEbGNZtbjv6mzBbtXLL5Bl8LzPxA==", "9f91e9cc-82b0-4725-b6c8-530d5f60c7e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "RequestId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "6a6c1bbf-a2cc-4f13-886d-8db07783f2bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "cea08a49-a28d-48b1-8f37-28382729f2d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "bc3dd1f4-9873-4009-b134-7650cf0a088b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6c06e8a-5471-479f-b243-ec7aa0dd4d73", "AQAAAAEAACcQAAAAEPRUAF6HyjHV74UX0IupMWXR2jg8Cdn1i95hbsBS3d7aB6k8+FOqIOww0Ac36M82qA==", "8f961299-3fbf-486d-81d4-13a35d8d3bdb" });
        }
    }
}
