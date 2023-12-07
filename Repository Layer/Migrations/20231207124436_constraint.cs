using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_doctorId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "bb800914-b683-4ddb-8b55-be1a342074d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "191cfa43-3537-4dab-97d9-b0a6c2735491");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "f53984fe-91f6-4f26-af37-20ff3832896a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed0d2d46-78a9-4e58-a832-d850b5a72c3e", "AQAAAAEAACcQAAAAEH1H9ngl5uYShCzyz0Qo3QubosNA6Jt/t9v9lVBSvF35ILEh5+DIloPIVLrtYZWwXg==", "c15a3122-22ee-402f-8c72-6c52fb49995f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_doctorId",
                table: "Appointments",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "id");
        }
    }
}
