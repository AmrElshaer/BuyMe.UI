using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class UpdateInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Shipments_ShipmentId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ShipmentId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShipmentId1",
                table: "Invoices");

            migrationBuilder.AlterColumn<long>(
                name: "ShipmentId",
                table: "Invoices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShipmentId",
                table: "Invoices",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Shipments_ShipmentId",
                table: "Invoices",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Shipments_ShipmentId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ShipmentId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ShipmentId1",
                table: "Invoices",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShipmentId1",
                table: "Invoices",
                column: "ShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Shipments_ShipmentId1",
                table: "Invoices",
                column: "ShipmentId1",
                principalTable: "Shipments",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
