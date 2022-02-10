using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addInvoiceRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0341bc5d-0415-4169-880d-7146717fa037");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18570971-2dac-49ed-9f5b-6b8485a75300");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bf88724-0b82-409f-856e-6bfc51f4ab35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355cf6c0-2192-47d1-9993-4961d33a63b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5acd2f-fd43-4c15-bab6-5ebaddaa9453");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47db9355-fa30-4d3e-abee-42c3b441514b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6077a724-ec4d-4b26-a90c-1fd5c63f4313");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74cd768a-f2e3-44a0-a6c1-42d03ff50b05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76e3e985-2d1f-4ba0-a3d6-3668fef48012");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b30b35-1cb4-4c84-9b91-f37a846633b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919a94ee-2cfa-4a1c-93a3-ff1f2d779ef3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33f072f-f3ba-458d-b80a-3fdebab1b453");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc8e8181-0865-4ed7-8ebe-197d05773389");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd5a95ae-ee89-435a-af20-068f6d09c3bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df45e25a-41bc-4dfd-8c62-ad12c60c088f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfd449dc-ec75-4d71-aa38-53ffc9df69be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed505e8b-409f-4240-88bc-06437b7c7033");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1709327-9d62-449f-a595-da7da616dfde", "18ce943f-5825-4b41-bbb7-f94bf39beb01", "Product", "Product" },
                    { "572fa09c-b4df-4e51-850d-81e8da537f42", "291e4fad-e414-4854-bce4-725a5e3204b2", "InvoiceType", "InvoiceType" },
                    { "568829a0-5503-4cda-a497-c6fd898d8796", "c16213f2-1e7d-4db5-89ed-1b1b564a89e4", "Shipment", "Shipment" },
                    { "9366fd52-2b29-40a7-b9f3-b27a78267b84", "096dec80-70b1-43d7-8bb9-9e03efe6a14f", "ShipmentType", "ShipmentType" },
                    { "a51a0bdb-ef2d-4b57-a571-4aa4e0cb4ef6", "9b495443-db34-471a-b450-ea844fae45bf", "ChangeRole", "ChangeRole" },
                    { "2d718961-72bd-4f5a-ad74-1f9ddaa12ae3", "491cb557-7b42-4427-91fb-00bba697b3d0", "User", "User" },
                    { "897519de-8b61-47c4-86f2-dd5e6e9d13e3", "6754f579-d9f8-45be-be57-5cb4cf1f48cd", "Settings", "Settings" },
                    { "79f4265f-3f6c-4a61-9f2d-ca9bf44823f1", "0bf0cbac-7ce2-474c-b90f-e003a1b3758a", "Template", "Template" },
                    { "734d3f1c-aa20-4163-8aaf-c6fa24e0772c", "1018461f-0852-4d15-aa89-4f7e438aede7", "Invoice", "Invoice" },
                    { "b7b518bb-41a6-4be3-9097-b55170697869", "b8315c41-f085-402b-8fad-bf1c2f40e85d", "Branch", "Branch" },
                    { "20dad39f-a149-4260-91ff-42f86b7d205d", "598a5218-b39d-4c97-a353-0976de7f03ae", "UnitOfMeasure", "UnitOfMeasure" },
                    { "1001fd67-9647-4dd5-9923-6f69842eb223", "fde3364f-d8b8-4115-b56d-a479f1f3062d", "Category", "Category" },
                    { "692109f5-eefd-48ae-9883-dbfbf4e90bc1", "9057dc67-0903-4e6a-be72-42d763b63ccb", "SalesOrder", "SalesOrder" },
                    { "4ef00198-c769-401c-b30a-8b5af61cee71", "7c6f7c02-fe57-4fa3-9a48-fe17a1e1da9d", "SalesType", "SalesType" },
                    { "9f88c8c7-5559-47e1-8baf-eef7bb210a96", "22e8f9bc-611f-4fea-8568-984672aa155c", "Customer", "Customer" },
                    { "70375a9a-f749-4bc3-9fac-1dd00628fb44", "d32580e7-55e4-4877-979d-7f3d9a9c34b1", "CustomerType", "CustomerType" },
                    { "bbd2c870-da10-44e6-9307-921233882cbb", "46693f2a-57de-43c4-ada1-a7da480aa845", "Warehouse", "Warehouse" },
                    { "2882e210-c58a-4dc2-ab57-fa5aaa634040", "4da53e2d-6bb6-4b9a-8c02-4660cf44494d", "Currency", "Currency" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe35f20f-2726-421c-a05c-4e279572cedd", "AQAAAAEAACcQAAAAEIhZwW99v3eDHZ1ljm8dzYC9Lre7CD38W+iPqTiAZa16N68DWNjKwZeJ0ufH+MZsvA==", "7b50c392-5d99-4c47-909e-40a6cc6c3417" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1001fd67-9647-4dd5-9923-6f69842eb223");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20dad39f-a149-4260-91ff-42f86b7d205d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2882e210-c58a-4dc2-ab57-fa5aaa634040");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d718961-72bd-4f5a-ad74-1f9ddaa12ae3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ef00198-c769-401c-b30a-8b5af61cee71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "568829a0-5503-4cda-a497-c6fd898d8796");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572fa09c-b4df-4e51-850d-81e8da537f42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "692109f5-eefd-48ae-9883-dbfbf4e90bc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70375a9a-f749-4bc3-9fac-1dd00628fb44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "734d3f1c-aa20-4163-8aaf-c6fa24e0772c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79f4265f-3f6c-4a61-9f2d-ca9bf44823f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897519de-8b61-47c4-86f2-dd5e6e9d13e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9366fd52-2b29-40a7-b9f3-b27a78267b84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f88c8c7-5559-47e1-8baf-eef7bb210a96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a51a0bdb-ef2d-4b57-a571-4aa4e0cb4ef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b518bb-41a6-4be3-9097-b55170697869");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbd2c870-da10-44e6-9307-921233882cbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1709327-9d62-449f-a595-da7da616dfde");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6077a724-ec4d-4b26-a90c-1fd5c63f4313", "3178bf30-fddd-43a2-96d8-8c611b498273", "Product", "Product" },
                    { "cc8e8181-0865-4ed7-8ebe-197d05773389", "ca8a5b2d-cf35-47c8-a5df-31082dbc2705", "Shipment", "Shipment" },
                    { "1bf88724-0b82-409f-856e-6bfc51f4ab35", "12b90968-1b40-43a1-9073-3d1d70f37836", "ShipmentType", "ShipmentType" },
                    { "84b30b35-1cb4-4c84-9b91-f37a846633b4", "4a07f537-cfd8-47f7-82d4-ad137bd0ce72", "ChangeRole", "ChangeRole" },
                    { "3c5acd2f-fd43-4c15-bab6-5ebaddaa9453", "b3b5a057-d4d1-48af-ae49-026ca2d59dc9", "User", "User" },
                    { "919a94ee-2cfa-4a1c-93a3-ff1f2d779ef3", "6ac21901-c413-4b1b-9cfb-7bbc172d60b9", "Settings", "Settings" },
                    { "18570971-2dac-49ed-9f5b-6b8485a75300", "34f77081-e992-459c-9cc4-a0cea750e019", "Template", "Template" },
                    { "c33f072f-f3ba-458d-b80a-3fdebab1b453", "88e9924b-2dac-40a7-b757-7d469dd99e9d", "Branch", "Branch" },
                    { "dfd449dc-ec75-4d71-aa38-53ffc9df69be", "4b57636a-4c36-4a88-ac52-46f04294183c", "Currency", "Currency" },
                    { "355cf6c0-2192-47d1-9993-4961d33a63b9", "37263905-3161-425e-9f80-800a50cff901", "UnitOfMeasure", "UnitOfMeasure" },
                    { "df45e25a-41bc-4dfd-8c62-ad12c60c088f", "dd708308-5c3a-4a66-916f-d6e23ae87660", "Category", "Category" },
                    { "0341bc5d-0415-4169-880d-7146717fa037", "58af0a53-05e5-4b99-82c5-7349996f23ce", "SalesOrder", "SalesOrder" },
                    { "76e3e985-2d1f-4ba0-a3d6-3668fef48012", "f8670b50-6a09-4e9a-a167-c9f29aef5628", "SalesType", "SalesType" },
                    { "ed505e8b-409f-4240-88bc-06437b7c7033", "05d866ca-36e3-4c06-aed6-bab3a6b1539e", "Customer", "Customer" },
                    { "cd5a95ae-ee89-435a-af20-068f6d09c3bc", "a237585e-4d18-4741-a56b-406fe3ea55aa", "CustomerType", "CustomerType" },
                    { "47db9355-fa30-4d3e-abee-42c3b441514b", "f901502a-4745-40ab-ad36-e83121725b2d", "Warehouse", "Warehouse" },
                    { "74cd768a-f2e3-44a0-a6c1-42d03ff50b05", "7ef123b4-aaf9-406a-91ae-e71866aa83db", "InvoiceType", "InvoiceType" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc242665-5913-4a62-8802-1d75b34cdc96", "AQAAAAEAACcQAAAAEOyPvkpiRUgAhAK1f9UaIPphuJO3psM7Zsewkq1vSpnpgaQW6U2dRralTik94V3f2w==", "befd5c69-e1db-437c-9456-3bd4ff54c6ac" });
        }
    }
}
