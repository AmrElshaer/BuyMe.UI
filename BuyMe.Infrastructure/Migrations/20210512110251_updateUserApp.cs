using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class updateUserApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3035420a-c019-4b3b-8df8-2ee427fb698c", "AQAAAAEAACcQAAAAEF8gilzDin+8iKR6Ry8fPvRnXmqzl4+Mvqi41BNg4+BoaFlvJUKHk2EopwTl7RC71g==", "8772af34-b178-419d-9515-45d440408deb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6d4c770-9be3-42a8-bec2-17180e36268f", "AQAAAAEAACcQAAAAEDm8ihPtF1e0IgJvwoAe6/1OD/ufWdI/99gfghUeXW8Z8fqheVvsk+Z4DRQ5YpWAgQ==", "2fbb7cea-4172-4a91-bdcf-4e7e18322ded" });
        }
    }
}