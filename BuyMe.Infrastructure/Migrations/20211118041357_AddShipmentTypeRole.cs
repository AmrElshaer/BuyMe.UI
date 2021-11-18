using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class AddShipmentTypeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08a51069-6a21-41cf-94b7-0215c4a792e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16230023-046c-42cb-9b4b-537256035a0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18585ed4-36da-49eb-bb61-5849e7410c07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "403f812a-2bd8-4a4e-8b95-b57c7ff6b60a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a8535b2-94c4-4e23-9243-32c41dfe0166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a28422c-a94e-47d3-a214-b8ad5a5bcba1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74d27860-7971-4482-a2ae-71afeabeffb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f59802d-523e-4ce6-af58-4903e69e608b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91b2eb66-df61-4099-a260-809943f916cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a451d8e8-9971-478f-9445-0e317c444d0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8eada1e-8c4f-4584-8459-5d4d15ed2133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac45189f-fbb5-4326-aec0-d11641912a2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af55af7e-f632-4ae9-997a-aa62adf01dca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f251e444-ef7b-4b5e-b414-b4b47accb1c8");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "74d27860-7971-4482-a2ae-71afeabeffb2", "7856989a-0185-47c7-a8a7-b8621e96e4da", "Product", "Product" },
                    { "a451d8e8-9971-478f-9445-0e317c444d0d", "534048dd-126c-44b1-8daf-13da5c8e51cd", "Warehouse", "Warehouse" },
                    { "5a28422c-a94e-47d3-a214-b8ad5a5bcba1", "903cc4ae-1859-4fb2-a381-23dbbc7dddf4", "CustomerType", "CustomerType" },
                    { "a8eada1e-8c4f-4584-8459-5d4d15ed2133", "1b0f59f1-3262-4853-8053-65f721763d6c", "Customer", "Customer" },
                    { "4a8535b2-94c4-4e23-9243-32c41dfe0166", "64fa895e-bae7-4986-b9ad-97606ed30753", "SalesType", "SalesType" },
                    { "403f812a-2bd8-4a4e-8b95-b57c7ff6b60a", "c6ab2a6c-d1f9-4091-a191-77306bcaa51b", "SalesOrder", "SalesOrder" },
                    { "16230023-046c-42cb-9b4b-537256035a0a", "ec26bdfa-e1cb-4c11-aa2a-af224aaf1b54", "Category", "Category" },
                    { "f251e444-ef7b-4b5e-b414-b4b47accb1c8", "d63c072e-321d-4fb8-bc5a-eb17a833117e", "UnitOfMeasure", "UnitOfMeasure" },
                    { "91b2eb66-df61-4099-a260-809943f916cb", "6cef88f4-f0cd-48e7-ba24-817da1f14799", "Currency", "Currency" },
                    { "af55af7e-f632-4ae9-997a-aa62adf01dca", "d488556e-2172-464d-bd37-2fa0600f8886", "Branch", "Branch" },
                    { "18585ed4-36da-49eb-bb61-5849e7410c07", "e857d061-1c50-4501-9811-c2fbaf5cc7ab", "Template", "Template" },
                    { "08a51069-6a21-41cf-94b7-0215c4a792e3", "89e6786e-53ab-4396-b8e3-2287271d1f92", "Settings", "Settings" },
                    { "7f59802d-523e-4ce6-af58-4903e69e608b", "3c2e5baa-9d69-44fd-9c57-56b8ca3e21e4", "User", "User" },
                    { "ac45189f-fbb5-4326-aec0-d11641912a2c", "1e9fcb8e-bc7c-4ac2-b20c-cc5ffa342b6c", "ChangeRole", "ChangeRole" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c992e56b-b482-4e05-bc77-01c00fcd6478", "AQAAAAEAACcQAAAAECNxD97JMKRv5L6xIjXFPnJ3xObX+zhw1lAoS9+chBqLQKkiBxAC9iFPa2T4CvPoRg==", "94854539-fee9-4167-b702-4de13e035c4f" });
        }
    }
}
