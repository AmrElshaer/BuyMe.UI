using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18f6affb-91ea-4bae-a672-5f6f5a4df952", "AQAAAAEAACcQAAAAEEPSQG46Qc3LPCdqhJwZjJtyEZXg0CZP3I01pZQSjkA6oLmC6DLQLZtgq20JYurH1g==", "041d68eb-3e34-41c0-a727-91f56fa0e676" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0cfe5d4-9e44-433d-b4e1-a314256a3889", "AQAAAAEAACcQAAAAEL28q+O0vtcbxhtSCzJEc5IBppTs1/daR5p61aAwi0zm6nOAbQi2pclrLd/19w+p8Q==", "d6a1336f-430d-4f7d-9c72-5a128bba4812" });
        }
    }
}
