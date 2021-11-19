using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addShipmentRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11c8e32f-cbdd-47f4-b315-c277934dc2dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cc039e1-7a7d-4427-b531-13a3e1fe237c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "427a56d6-0b60-419b-bc7f-04d87f835e81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d9a5f3d-9ebf-467b-9143-199a19dfe3a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "659123c8-8004-4b54-942b-9270b4d57514");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d569f3d-f883-4c04-9ac4-fc91a89b2710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a41b09-25b1-4344-a106-cb32fa87eacd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f340ca-f395-401c-8fe0-0f7118c4d37e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2fb565-9b0f-41be-b959-b9e72b8fd2d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf8e34a5-10f7-4bf3-b922-626122dbe426");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d080c973-0a32-4a3c-8aff-8ad4d4f535c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ad1077-29cc-4199-ad50-8bd3d5525f57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eab3d50a-116c-4cd5-9fce-16d1b9613f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb85422-dc8c-4e1c-acae-c4dfd281b56b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff15cf02-3762-47ca-a705-628de38482d1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "d080c973-0a32-4a3c-8aff-8ad4d4f535c3", "a5e0e028-3acb-4f6c-bbb9-6be7e3591e17", "Product", "Product" },
                    { "bf2fb565-9b0f-41be-b959-b9e72b8fd2d6", "4a90bec7-d201-4df6-bb72-fcaa0c524c75", "Warehouse", "Warehouse" },
                    { "e1ad1077-29cc-4199-ad50-8bd3d5525f57", "0a42600c-e25c-4aba-bf46-9b8a0ee187bf", "CustomerType", "CustomerType" },
                    { "eab3d50a-116c-4cd5-9fce-16d1b9613f49", "45fc9168-6294-4b12-962d-f851f3433556", "Customer", "Customer" },
                    { "5d9a5f3d-9ebf-467b-9143-199a19dfe3a0", "f144c5c6-e888-4e7d-a4ce-f4d3b734cd37", "SalesType", "SalesType" },
                    { "6d569f3d-f883-4c04-9ac4-fc91a89b2710", "b41bc59a-0fe1-4c8b-ae63-fe826ad497bd", "SalesOrder", "SalesOrder" },
                    { "98f340ca-f395-401c-8fe0-0f7118c4d37e", "94a84d0d-d916-410a-ab3f-50aadca5eccc", "Category", "Category" },
                    { "427a56d6-0b60-419b-bc7f-04d87f835e81", "cfc813c8-b77d-4247-9cec-999675d8a3c1", "UnitOfMeasure", "UnitOfMeasure" },
                    { "fcb85422-dc8c-4e1c-acae-c4dfd281b56b", "8baa3b8a-7ebb-4b1b-be6f-3f8d61c04108", "Currency", "Currency" },
                    { "659123c8-8004-4b54-942b-9270b4d57514", "1341381d-5565-4e25-9d41-2c13eda14177", "Branch", "Branch" },
                    { "ff15cf02-3762-47ca-a705-628de38482d1", "5a492a5e-e651-44a5-a498-7d4184770f38", "Template", "Template" },
                    { "2cc039e1-7a7d-4427-b531-13a3e1fe237c", "35b5fdd8-0a82-4e30-b68a-2723783a31ea", "Settings", "Settings" },
                    { "74a41b09-25b1-4344-a106-cb32fa87eacd", "8e2fb732-fe59-4853-bd44-d522374d3545", "User", "User" },
                    { "cf8e34a5-10f7-4bf3-b922-626122dbe426", "70e16198-1797-4c56-a997-3452c6bd6596", "ChangeRole", "ChangeRole" },
                    { "11c8e32f-cbdd-47f4-b315-c277934dc2dc", "bf440058-99f5-4603-a01d-e78124fd101f", "ShipmentType", "ShipmentType" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9faf35d1-d3a5-4c15-bae1-3b8e5f571b31", "AQAAAAEAACcQAAAAEHuBiLhc5UIi9FokAg9QXKuF5NHeUPg6FgHGV4T3Kx4yD+P6Ez5oET1HC0ktXqPPvg==", "92bfbc21-d179-4225-8fc4-fc7c91c9a3d2" });
        }
    }
}
