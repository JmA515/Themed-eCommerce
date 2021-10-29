using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class updateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73f10b2b-6818-4184-8a78-60cb4c05b59e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d4bf95c-c642-4c29-890d-d9285aa8bda2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "436399e4-8252-4176-b1f3-6888663fa0c1", "4c8b984d-38d9-44d8-baba-d2cf6d10411d", "User", "USER" },
                    { "434c34f0-2e39-4552-88cb-3a509ee51bc9", "dadf31d1-3121-4b9a-9b9d-7da13be08823", "Admin", "ADMIN" },
                    { "06a843b1-6a63-4af7-972f-9ecf03522f66", "a814dacb-a42b-4f72-813d-8c5e17dc6b41", "Buyer", "BUYER" },
                    { "a94386af-fc56-4528-9f0c-8b72bc8a1e9f", "60cb8e07-bfe5-46b3-a2b2-de287dd4011e", "Seller", "SELLER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06a843b1-6a63-4af7-972f-9ecf03522f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434c34f0-2e39-4552-88cb-3a509ee51bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "436399e4-8252-4176-b1f3-6888663fa0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94386af-fc56-4528-9f0c-8b72bc8a1e9f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d4bf95c-c642-4c29-890d-d9285aa8bda2", "89972649-7fc0-490e-a9d0-9b129ab4b045", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73f10b2b-6818-4184-8a78-60cb4c05b59e", "08ee4338-fa4d-468e-9014-ec7ec8b0a2b4", "Admin", "ADMIN" });
        }
    }
}
