using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class UpdateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TemplateId",
                table: "Companies",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Templates_TemplateId",
                table: "Companies",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Templates_TemplateId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_TemplateId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Companies");
        }
    }
}