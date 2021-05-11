using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6d4c770-9be3-42a8-bec2-17180e36268f", "ADMIN@BUYME.COM", "ADMIN@BUYME.COM", "AQAAAAEAACcQAAAAEDm8ihPtF1e0IgJvwoAe6/1OD/ufWdI/99gfghUeXW8Z8fqheVvsk+Z4DRQ5YpWAgQ==", "2fbb7cea-4172-4a91-bdcf-4e7e18322ded" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9da60a7c-85eb-424e-9126-67c195c3e4b6", null, null, "AQAAAAEAACcQAAAAEMloyLerldtI/4H+Gv8DFYjjnx+KXVPHpIRuxyoziqBHueZsgzXnhAE+dtt8H3vg7w==", "20bb30ec-2411-4854-8453-0abdcedf08c9" });
        }
    }
}
