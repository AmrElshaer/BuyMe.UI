using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class AddDefaultMarketingSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketingDefaultSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    SalesTypeId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingDefaultSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingDefaultSettings_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingDefaultSettings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketingDefaultSettings_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingDefaultSettings_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingDefaultSettings_SalesTypes_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalTable: "SalesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketingDefaultSettings_BranchId",
                table: "MarketingDefaultSettings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingDefaultSettings_CompanyId",
                table: "MarketingDefaultSettings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingDefaultSettings_CurrencyId",
                table: "MarketingDefaultSettings",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingDefaultSettings_CustomerTypeId",
                table: "MarketingDefaultSettings",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingDefaultSettings_SalesTypeId",
                table: "MarketingDefaultSettings",
                column: "SalesTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketingDefaultSettings");
        }
    }
}
