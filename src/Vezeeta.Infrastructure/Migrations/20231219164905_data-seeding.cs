using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vezeeta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a", "bb800914-b683-4ddb-8b55-be1a342074d8", "Patient", "PATIENT" },
                    { "63d379ae-8133-4256-b413-20b3a402dc8c", "191cfa43-3537-4dab-97d9-b0a6c2735491", "Doctor", "DOCTOR" },
                    { "e014c5f9-775e-4112-bbc9-5a6859f60a6a", "f53984fe-91f6-4f26-af37-20ff3832896a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, "ed0d2d46-78a9-4e58-a832-d850b5a72c3e", new DateTime(2001, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApplicationUser", "admin@vezeeta.com", true, "sara abdelsalam", 0, null, false, null, "ADMIN@VEZEETA.COM", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "AQAAAAIAAYagAAAAEKMBRQBVIigkwF0WmhhWBKYmVG9A40NEYgX4kVmeyclC1Nf9vwXvTyT5DS6ZzOAZPQ==", "01021122226", false, "c15a3122-22ee-402f-8c72-6c52fb49995f", false, "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "ID", "SpecializationName" },
                values: new object[,]
                {
                    { 1, "Dermatology" },
                    { 2, "Dentistry" },
                    { 3, "Nutrition" },
                    { 4, "Pediatrics" },
                    { 5, "Psychiatry" },
                    { 6, "Ear, Nose and Throat" },
                    { 7, "Orthopedics(Bones)" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e014c5f9-775e-4112-bbc9-5a6859f60a6a", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });
        }

        /// <inheritdoc />
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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e014c5f9-775e-4112-bbc9-5a6859f60a6a", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
        }
    }
}
