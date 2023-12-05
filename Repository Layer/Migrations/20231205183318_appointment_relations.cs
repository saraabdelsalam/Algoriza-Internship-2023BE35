using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class appointment_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_docid",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_times_Appointments_Appointmentid",
                table: "times");

            migrationBuilder.RenameColumn(
                name: "Appointmentid",
                table: "times",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_times_Appointmentid",
                table: "times",
                newName: "IX_times_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "docid",
                table: "Appointments",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_docid",
                table: "Appointments",
                newName: "IX_Appointments_doctorId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time",
                table: "times",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
                name: "FK_Appointments_Doctors_doctorId",
                table: "Appointments",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_times_Appointments_AppointmentId",
                table: "times",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_doctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_times_Appointments_AppointmentId",
                table: "times");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "times",
                newName: "Appointmentid");

            migrationBuilder.RenameIndex(
                name: "IX_times_AppointmentId",
                table: "times",
                newName: "IX_times_Appointmentid");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "Appointments",
                newName: "docid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_doctorId",
                table: "Appointments",
                newName: "IX_Appointments_docid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "times",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_docid",
                table: "Appointments",
                column: "docid",
                principalTable: "Doctors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_times_Appointments_Appointmentid",
                table: "times",
                column: "Appointmentid",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
