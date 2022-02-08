using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class InvoiceRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05895c76-7c9e-41e4-bc3f-d299055caa6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13bc9449-0b4e-4f2e-8e37-977206d6db79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "406ee693-df69-4348-aec9-8ede2dea5c39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4385c3ee-ce00-4b50-8b92-8eef64e34717");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4628491c-4272-47d6-b724-766a241583c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4db0513f-3c21-41b6-b98c-ca3569e4e8f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e3dd48d-7070-4a60-b8ce-264a200f287f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "518aa4d2-61e4-4be4-aeba-82420ade0cc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57adc500-4c11-43e3-831f-a04071f00a18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0e15fe-082c-478c-9b7e-48ae576c8030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a351a12f-3293-409d-ac1a-45618e0bd2b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a56a9a3e-89a7-440b-b86a-6d9886f2e464");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5478c34-039c-4e38-abf3-23d617e088a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8be69fb-2f79-4b79-9655-e2c2aadb6bcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1acdc9e-9d51-4441-9a4f-991d58f5e597");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faf8c0d4-ae2e-42c3-bf2c-a1ab6d667f7e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "a56a9a3e-89a7-440b-b86a-6d9886f2e464", "29683a65-f1aa-45cb-ad6f-34ed0db464e2", "Product", "Product" },
                    { "a351a12f-3293-409d-ac1a-45618e0bd2b2", "511b84fa-5e8a-4a94-9810-2270f323fc43", "ShipmentType", "ShipmentType" },
                    { "4385c3ee-ce00-4b50-8b92-8eef64e34717", "9c4a487b-d943-42ae-a885-a1bade6b8549", "ChangeRole", "ChangeRole" },
                    { "4db0513f-3c21-41b6-b98c-ca3569e4e8f4", "f08d7fc2-565d-4b8d-b77e-1fb7cb0c1cf4", "User", "User" },
                    { "406ee693-df69-4348-aec9-8ede2dea5c39", "e9effdd2-1b09-4c9b-a452-aea888d175c5", "Settings", "Settings" },
                    { "d8be69fb-2f79-4b79-9655-e2c2aadb6bcd", "2d674b38-dd57-4953-9cd9-6ef7ff9ae40b", "Template", "Template" },
                    { "05895c76-7c9e-41e4-bc3f-d299055caa6e", "fbdfbc7d-544e-4aba-8d68-662fe06c41ed", "Branch", "Branch" },
                    { "13bc9449-0b4e-4f2e-8e37-977206d6db79", "1157a8f5-9d98-4b35-9cb7-5530089f5e1d", "Shipment", "Shipment" },
                    { "4628491c-4272-47d6-b724-766a241583c0", "d9fde5d0-321c-4dfb-b6ac-4a14ca096597", "Currency", "Currency" },
                    { "f1acdc9e-9d51-4441-9a4f-991d58f5e597", "dc9aec66-c49a-439c-b72f-2bff754e8740", "Category", "Category" },
                    { "6f0e15fe-082c-478c-9b7e-48ae576c8030", "40a98b20-fc21-4439-a6c8-b7fb649862bb", "SalesOrder", "SalesOrder" },
                    { "57adc500-4c11-43e3-831f-a04071f00a18", "c3ce2344-ff9e-434f-800f-fb5f89dfb7d5", "SalesType", "SalesType" },
                    { "faf8c0d4-ae2e-42c3-bf2c-a1ab6d667f7e", "755e1b3f-eaa4-40cc-85e0-f13e4648e805", "Customer", "Customer" },
                    { "518aa4d2-61e4-4be4-aeba-82420ade0cc5", "742e5bf2-9c75-486b-9d8b-b78f6c8d0c1e", "CustomerType", "CustomerType" },
                    { "d5478c34-039c-4e38-abf3-23d617e088a2", "0166ac16-2e5c-410b-b395-e7c676d41057", "Warehouse", "Warehouse" },
                    { "4e3dd48d-7070-4a60-b8ce-264a200f287f", "a438b38f-bb24-438c-b67e-161ab2442921", "UnitOfMeasure", "UnitOfMeasure" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21bcebd6-b695-4635-8dcb-516cf6ff4938", "AQAAAAEAACcQAAAAEBsRRxsfqk8ZpNHsCOzDeOEX2EsYdF3KpfoOMD+65f3UjDCp6n+ELUpF4A0IVQscXA==", "8d1a7e50-6d01-46e5-9c3d-8fbbc34def44" });
        }
    }
}
