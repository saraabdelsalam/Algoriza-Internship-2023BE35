using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_discountCodes_DiscountCodeid",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DiscountCodeid",
                table: "Requests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088d79c8-3d70-4bef-9158-4a7fde4d0dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c5d1c6-823a-4014-9d42-400af158c2ce");

            migrationBuilder.DropColumn(
                name: "DiscountCodeid",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "b8a06c20-77fa-4650-abc6-a5784c486a3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a", "35d3b2bc-f817-4c56-96d8-bc68c57c1fd4", "Patient", "PATIENT" },
                    { "63d379ae-8133-4256-b413-20b3a402dc8c", "b28c4dc5-d330-4cbb-9880-a0684cd194d5", "Doctor", "DOCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294aaa33-9c90-45e8-bb82-8df95c545ef1", "AQAAAAEAACcQAAAAEPvuaFaoLHG4AcztgiCtLGLrF8MsYzNowGONLe1V0NibXpb9XUCiy3pEuEul+/wI8Q==", "c12b660b-b1c6-4f4a-8efa-7478e2cf0efd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeid",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "0019c1b2-d136-48ba-85a1-f9d055a64da6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "088d79c8-3d70-4bef-9158-4a7fde4d0dce", "60e0517f-bc8c-4b2a-a443-001a210c5586", "Doctor", "DOCTOR" },
                    { "e3c5d1c6-823a-4014-9d42-400af158c2ce", "30ad168f-0a2e-4a05-b3d8-00b6f204e8e7", "Patient", "PATIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e42f2d2-91f6-4483-8e7a-33be2329c58b", "AQAAAAEAACcQAAAAEGi+H0RthAkKvZivagnwkAqvKouckqKghYMotYnq8hgl9kNXlykfSU9rQEQ3hpiISg==", "19eb6b9a-84e0-4671-b0a6-e376a88474a4" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DiscountCodeid",
                table: "Requests",
                column: "DiscountCodeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_discountCodes_DiscountCodeid",
                table: "Requests",
                column: "DiscountCodeid",
                principalTable: "discountCodes",
                principalColumn: "id");
        }
    }
}
