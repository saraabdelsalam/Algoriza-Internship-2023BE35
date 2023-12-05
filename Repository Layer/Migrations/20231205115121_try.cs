using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "ae336d04-606f-4c3f-8e9e-c9531f5b3f4f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16f378cf-271b-46c5-86ff-d9df6e8db7ca", "2a1fcf92-e393-4832-a9e2-438f966edbac", "Patient", "PATIENT" },
                    { "e255b369-d241-4bc3-b957-aeee19b42f97", "07470615-42ba-40ac-a0b6-bc5d813f0514", "Doctor", "DOCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c528a82-2343-43fc-834e-fe4376055b99", "AQAAAAEAACcQAAAAED78xGS4GGuK9y8z3+xqntGBRJGH2vnBShKDBFNiiDfUVS9FTLmq1LvkAELXekzLdg==", "bb8285ae-3e90-4897-8c2f-a3025563d554" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16f378cf-271b-46c5-86ff-d9df6e8db7ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e255b369-d241-4bc3-b957-aeee19b42f97");

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
    }
}
