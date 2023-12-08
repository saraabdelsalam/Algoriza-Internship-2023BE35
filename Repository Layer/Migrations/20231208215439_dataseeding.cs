using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "DateOfBirth", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { new DateTime(2001, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMIN@VEZEETA.COM", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "AQAAAAEAACcQAAAAEA5DByYj2jaUzG5+ABIhw3cDWJ5pVR+4VDJL5otdR5T/bGBKLVLJZzv69Lfwqk/LRA==", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "specializations",
                columns: new[] { "id", "SpecializationName" },
                values: new object[,]
                {
                    { 4, "Pediatrics" },
                    { 5, "Psychiatry" },
                    { 6, "Ear, Nose and Throat" },
                    { 7, "Orthopedics(Bones)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "DateOfBirth", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara abdelsalam", "AQAAAAEAACcQAAAAEH1H9ngl5uYShCzyz0Qo3QubosNA6Jt/t9v9lVBSvF35ILEh5+DIloPIVLrtYZWwXg==", "sara abdelsalam" });
        }
    }
}
