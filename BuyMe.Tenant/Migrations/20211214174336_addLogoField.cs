using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Tenant.Migrations
{
    public partial class addLogoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantLogo",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantLogo",
                table: "Tenants");
        }
    }
}
