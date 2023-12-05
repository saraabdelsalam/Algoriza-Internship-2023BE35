using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "cdfbb7fe-f2fb-47eb-818b-f240bb4ca3b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a", "c073ff46-1101-446c-a6e9-db6b2ae5d54c", "Patient", "PATIENT" },
                    { "63d379ae-8133-4256-b413-20b3a402dc8c", "3514ee7d-caf2-4c32-94ab-8e2f7dfaedf2", "Doctor", "DOCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b86d55-3219-4ab3-8064-6f87bba7a7d4", "AQAAAAEAACcQAAAAEG1jRC9hNRFIOgtTT4X2/y2Hr14NCyHqbaQQ2K41v2U56BEpoSbQcJETTU6lhFH1oA==", "a0d190e2-943b-406d-9aa6-cb0ef422671e" });
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
    }
}
