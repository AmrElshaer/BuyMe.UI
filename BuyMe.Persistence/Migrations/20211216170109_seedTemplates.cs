using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class seedTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "eshop" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "coza" });

            migrationBuilder.InsertData(
                table: "TemplateImages",
                columns: new[] { "Id", "ImageName", "TemplateId" },
                values: new object[] { 1, "eShop.jpg", 1 });

            migrationBuilder.InsertData(
                table: "TemplateImages",
                columns: new[] { "Id", "ImageName", "TemplateId" },
                values: new object[] { 2, "cozaStore.png", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TemplateImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
