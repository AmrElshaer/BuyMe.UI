using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class updateFieldCustomData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldDatas_CustomFields_CustomFieldId",
                table: "CustomFieldDatas");

            migrationBuilder.RenameColumn(
                name: "CustomFieldId",
                table: "CustomFieldDatas",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFieldDatas_CustomFieldId",
                table: "CustomFieldDatas",
                newName: "IX_CustomFieldDatas_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "CustomFieldDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldDatas_Companies_CompanyId",
                table: "CustomFieldDatas",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldDatas_Companies_CompanyId",
                table: "CustomFieldDatas");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "CustomFieldDatas");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CustomFieldDatas",
                newName: "CustomFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFieldDatas_CompanyId",
                table: "CustomFieldDatas",
                newName: "IX_CustomFieldDatas_CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldDatas_CustomFields_CustomFieldId",
                table: "CustomFieldDatas",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
