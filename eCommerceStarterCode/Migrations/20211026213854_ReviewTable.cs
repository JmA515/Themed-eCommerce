using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class ReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1369ce08-e67f-4e12-b80b-9913395bb99d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "250a40f4-501a-4c18-ae50-3db9867ec36a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9af8975f-88db-4dad-b7b6-fff5e0e13365", "cc5e031b-e43d-4308-8033-f57da621ccfb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49952a05-e712-405d-af0d-c2ea2c52b01b", "ff95a3f7-4358-4942-91ae-20484211c3f8", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49952a05-e712-405d-af0d-c2ea2c52b01b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af8975f-88db-4dad-b7b6-fff5e0e13365");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1369ce08-e67f-4e12-b80b-9913395bb99d", "027ce512-38cd-4b4e-9bec-d2897d77c71c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "250a40f4-501a-4c18-ae50-3db9867ec36a", "33cc77b3-cb90-40bd-9840-288f792276ba", "Admin", "ADMIN" });
        }
    }
}
