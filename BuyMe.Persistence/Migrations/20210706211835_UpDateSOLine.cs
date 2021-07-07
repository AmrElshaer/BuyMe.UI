using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Persistence.Migrations
{
    public partial class UpDateSOLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Products_ProductId",
                table: "SalesOrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_SalesOrders_SalesOrderId1",
                table: "SalesOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderLines_SalesOrderId1",
                table: "SalesOrderLines");

            migrationBuilder.DropColumn(
                name: "SalesOrderId1",
                table: "SalesOrderLines");

            migrationBuilder.AlterColumn<long>(
                name: "SalesOrderId",
                table: "SalesOrderLines",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SalesOrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLines_SalesOrderId",
                table: "SalesOrderLines",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Products_ProductId",
                table: "SalesOrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_SalesOrders_SalesOrderId",
                table: "SalesOrderLines",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Products_ProductId",
                table: "SalesOrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_SalesOrders_SalesOrderId",
                table: "SalesOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderLines_SalesOrderId",
                table: "SalesOrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "SalesOrderId",
                table: "SalesOrderLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SalesOrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesOrderId1",
                table: "SalesOrderLines",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLines_SalesOrderId1",
                table: "SalesOrderLines",
                column: "SalesOrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Products_ProductId",
                table: "SalesOrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_SalesOrders_SalesOrderId1",
                table: "SalesOrderLines",
                column: "SalesOrderId1",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
