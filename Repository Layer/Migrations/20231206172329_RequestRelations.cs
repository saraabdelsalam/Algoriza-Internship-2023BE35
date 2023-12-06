using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class RequestRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Doctors_Doctorid",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_times_timeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "finalPrice",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "timeId",
                table: "Requests",
                newName: "TimeId");

            migrationBuilder.RenameColumn(
                name: "Doctorid",
                table: "Requests",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_timeId",
                table: "Requests",
                newName: "IX_Requests_TimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_Doctorid",
                table: "Requests",
                newName: "IX_Requests_DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeId",
                table: "Requests",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DiscountCodeId",
                table: "Requests",
                column: "DiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId",
                table: "Requests",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_discountCodes_DiscountCodeId",
                table: "Requests",
                column: "DiscountCodeId",
                principalTable: "discountCodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Doctors_DoctorId",
                table: "Requests",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Times_TimeId",
                table: "Requests",
                column: "TimeId",
                principalTable: "times",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_discountCodes_DiscountCodeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Doctors_DoctorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Times_TimeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DiscountCodeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DiscountCodeId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "TimeId",
                table: "Requests",
                newName: "timeId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Requests",
                newName: "Doctorid");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_TimeId",
                table: "Requests",
                newName: "IX_Requests_timeId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_DoctorId",
                table: "Requests",
                newName: "IX_Requests_Doctorid");

            migrationBuilder.AlterColumn<int>(
                name: "timeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "finalPrice",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a",
                column: "ConcurrencyStamp",
                value: "eaa7534f-eeca-46ad-8dc5-aeda600416ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d379ae-8133-4256-b413-20b3a402dc8c",
                column: "ConcurrencyStamp",
                value: "ab45c8da-8396-4c82-b9aa-341cb70600ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "f7aaa446-5824-498d-85dc-5e117e53bf1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "739e8aad-6d52-494c-b563-e06c7de76340", "AQAAAAEAACcQAAAAEEyQR8sRgLBmakDMLPZLkbyesznERt7ZFb815ZWBzihEIblzNWzju6h3MsP4Ye/V9w==", "583fb8d8-2b2b-4dae-bed3-83ba745a3f50" });

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId",
                table: "Requests",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Doctors_Doctorid",
                table: "Requests",
                column: "Doctorid",
                principalTable: "Doctors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_times_timeId",
                table: "Requests",
                column: "timeId",
                principalTable: "times",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
