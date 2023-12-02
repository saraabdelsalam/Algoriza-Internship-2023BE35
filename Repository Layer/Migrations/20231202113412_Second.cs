using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1-admin", "b99596f6-6703-477a-9194-7620573c9be7", "admin", "admin" },
                    { "2-doctor", "e7769cfa-e837-4b11-83ad-73e24f6df4a7", "doctor", "doctor" },
                    { "3-patient", "0e72c96f-47df-4c05-b62e-e3d8a6c6b8ea", "patient", "patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "gender", "image" },
                values: new object[] { "1", 0, "a0677852-a1a2-414f-a2e4-334b0a16a6b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@vezeeta.com", true, false, null, null, "sara abdelsalam", "AQAAAAEAACcQAAAAENf1+b7CVcjb7eIMTZoCvthJ2wUhS76j52rCodjxjIjY7TuE2JgbLXEVPquCVY/Jhw==", "01021122226", false, "888b94fc-e2e8-4760-b62a-e883e317b7dd", false, "sara abdelsalam", 0, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1-admin", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2-doctor");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3-patient");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1-admin", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1-admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
