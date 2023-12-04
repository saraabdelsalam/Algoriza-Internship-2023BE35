using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f9279f-3572-4994-acac-2048071ab9d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947f3b28-c7cc-4309-bbf0-023ac6f207a4");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088d79c8-3d70-4bef-9158-4a7fde4d0dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c5d1c6-823a-4014-9d42-400af158c2ce");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e014c5f9-775e-4112-bbc9-5a6859f60a6a",
                column: "ConcurrencyStamp",
                value: "80054619-cfb9-4d90-b003-be8f47123ff5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84f9279f-3572-4994-acac-2048071ab9d9", "d322cd00-4e56-49e7-9d06-2443b0480096", "Doctor", "DOCTOR" },
                    { "947f3b28-c7cc-4309-bbf0-023ac6f207a4", "ebf56277-fc6e-4d6f-8112-750f04db599f", "Patient", "PATIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "122a68e5-4cc2-4d4f-abd4-77b89bd2854d", "AQAAAAEAACcQAAAAEFA5eCirYG0KCOHP32J7w3KBagnJ8KOUHS2KR/1ikczy8vdh6+NFeG1zAty/n8HxCw==", "012ffeb2-eb5b-4f05-8d27-86825d8cdab2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
