using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "cc14c763-78c1-404d-aba0-fbc52d46082c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "988f6fc7-e1c4-4e66-8ea0-9a84d0418c9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "1e2bcf3b-66f9-4405-a72d-5f21f8406799");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1712f35e-0987-43ec-928a-29cb67e39704", "AQAAAAEAACcQAAAAEOMLucXvDpbpSGLu1fF6vXV7PLFVbfXdWn06FDEW/J4PnB742+lYnfQrQDpz5n96HA==", "32d24df3-f59b-4442-8848-3b8036a53da6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "c073ff46-1101-446c-a6e9-db6b2ae5d54c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "3514ee7d-caf2-4c32-94ab-8e2f7dfaedf2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "cdfbb7fe-f2fb-47eb-818b-f240bb4ca3b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b86d55-3219-4ab3-8064-6f87bba7a7d4", "AQAAAAEAACcQAAAAEG1jRC9hNRFIOgtTT4X2/y2Hr14NCyHqbaQQ2K41v2U56BEpoSbQcJETTU6lhFH1oA==", "a0d190e2-943b-406d-9aa6-cb0ef422671e" });
        }
    }
}
