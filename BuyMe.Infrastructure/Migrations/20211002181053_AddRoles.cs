using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c197a818-0150-4793-92a1-2f779cb0852d", "AQAAAAEAACcQAAAAEHB8TyLzx4MJGVAr+z3pkCfNW/4qDhorBK4XNw7OrMucsAZxbOeTKGAjdAdOEYO07Q==", "3a27a090-9824-4e19-bfa5-195fa7db4c9e" });
        }
    }
}
