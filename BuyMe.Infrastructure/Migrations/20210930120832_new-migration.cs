using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c197a818-0150-4793-92a1-2f779cb0852d", "AQAAAAEAACcQAAAAEHB8TyLzx4MJGVAr+z3pkCfNW/4qDhorBK4XNw7OrMucsAZxbOeTKGAjdAdOEYO07Q==", "3a27a090-9824-4e19-bfa5-195fa7db4c9e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b60a97ed-2f73-4321-9d74-9f48c7534387", "AQAAAAEAACcQAAAAEBppUsoTCEUHIB2nxVv92+cdggbJ4tz6eAP5CU7hqjl5vdRVsxqZPIvuzXbx8fnpuw==", "50ddc32a-962f-4b65-a914-58130f71ebd5" });
        }
    }
}
