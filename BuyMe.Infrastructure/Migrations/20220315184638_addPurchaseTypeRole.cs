using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addPurchaseTypeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "016c3ff2-2ed6-4df2-a3bc-b4892c4c4b97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "296512bf-f15a-4499-bad6-1ef1a6cc1418");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eb006d7-c828-483e-a5f6-3c45c33ce653");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "580d0db4-b0d2-408d-983e-0d6fbd1999f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6363ea16-8ee3-4e8e-b552-c2fec0e805ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b70e94-598b-4844-97c8-117677b54d5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89c02269-dc40-4855-ab44-cab18c948831");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cd89f28-784c-4d56-88f0-f72bad5c2daf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c36d81-36b8-4620-9404-7e28dde91525");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967502cc-b272-4c76-ba79-a0e7e555b145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2233469-9a4e-4dbc-89c8-2301e0f02c4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a767bb-4103-4824-b54c-ceb2a8ce97fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fc7e36-db55-4be5-acdd-8a3cdc03373c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c31a9c08-20cf-4bdf-b4e0-f304ce6ac1fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c38da81b-231b-4a17-85d7-532c788bc610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ff0382-9320-4565-bb25-25cd8f7e72a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6368780-1374-48c9-be39-3eedebef0d43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0216fe-8441-4f1a-b981-b8077ca48478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c5026e-7425-42f2-9e76-b9e44510c4b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9aba7ee-c6fe-43d4-bf5b-9957fde39dc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec477481-5fa5-4b6a-9be2-323246d2fbd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0e4e0ac-7e8e-4e34-b174-17361c80f015");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6963347a-3c97-4067-a25a-020b554d23e1", "4375769a-e07d-4ba6-8b80-e2940d4935ca", "Product", "Product" },
                    { "7cf2b0db-235f-4852-931e-4814fa21398f", "0204daf4-7df7-4cbe-bb65-1921693d0d6c", "Vendor", "Vendor" },
                    { "a4efd654-286b-4bc5-9813-3b2beaa4f37d", "859ae86d-82e5-4f21-a05d-891e5a128f2b", "VendorType", "VendorType" },
                    { "cf99949a-1437-4ef5-8b65-49c3a897c985", "875b6e34-c85c-48d2-a2af-bdd5b3e34f9e", "PaymentReceive", "PaymentReceive" },
                    { "f7a7c928-38e4-4d12-a9a8-fdc62eb41c35", "79a25074-108b-488a-a7da-551a486c70dc", "PaymentType", "PaymentType" },
                    { "13db4ca9-3847-4ff0-afb6-8792a3844cb0", "07cfd35b-c9c8-4393-9081-43cc697c150f", "Invoice", "Invoice" },
                    { "ca24589f-fa06-4652-b33d-bec2a092d2b1", "47d897a4-7e7b-4b31-bea1-869dc69e1bfa", "InvoiceType", "InvoiceType" },
                    { "ce85f325-e870-4835-8eaa-d914bb4a4d24", "799cea13-186e-4009-90e4-b2427e859421", "Shipment", "Shipment" },
                    { "7f470d75-8230-4f35-beb2-a74c495c546e", "e12f717b-a8cd-4e25-9b58-8f5611d58b4e", "ShipmentType", "ShipmentType" },
                    { "90181d29-4fb3-42d7-827d-6a3202e1e376", "8010ed2e-0a53-4959-8bf5-c87eb3ecd538", "ChangeRole", "ChangeRole" },
                    { "f0577cce-bf19-4df1-b904-91e30428fe03", "2ed5bf0c-f64e-488c-8cbf-935101c87329", "User", "User" },
                    { "c053a238-3bf3-4884-afc7-437231832702", "189f4b9b-719f-4877-a5d4-156e640397af", "Settings", "Settings" },
                    { "3da9d6b8-d8a9-4136-8757-a3ee6551a7ed", "72cd4310-206a-411b-a7a5-36c01791c8a2", "Template", "Template" },
                    { "2922c843-42d7-414c-8e75-3c6d4ff41a75", "8a9e7238-4552-43e9-a104-12eb9750ed24", "Branch", "Branch" },
                    { "65f4d565-c15c-434b-8e16-6832143e66df", "5dcb5c12-2720-431a-8bbd-aa548176ce40", "Currency", "Currency" },
                    { "458117b2-049d-4745-b403-457c74c34ac5", "bf446d3d-1faf-45f1-8bf7-f57ad6437d1c", "UnitOfMeasure", "UnitOfMeasure" },
                    { "23b9f195-9efa-4249-baa2-21f4e0241b9e", "fed8562a-5873-45ec-879b-0d67746a7507", "Category", "Category" },
                    { "2a79d3b0-b86c-4610-bbf0-08ce903bf5e7", "af9f8a5d-a88d-4ea3-ba80-be18564cc01a", "SalesOrder", "SalesOrder" },
                    { "ac91ce43-4d87-4803-a7c6-f9adf952aac9", "4a77c14e-daea-4250-b651-b6d5f0d1191d", "SalesType", "SalesType" },
                    { "86144a8a-ba8e-44eb-98aa-44a14c42ccf3", "212eaa02-4e8d-4b94-9914-fc33a8d529f5", "Customer", "Customer" },
                    { "f10073f5-0e5e-482c-baf7-5fae98a0540a", "6ecb4428-a703-4f32-9ef6-21b6d108ae34", "CustomerType", "CustomerType" },
                    { "a0b910d1-4d89-4ab6-af0a-de2e74dbf815", "51973c8d-84d4-44dc-a51b-77ef3f040f0d", "Warehouse", "Warehouse" },
                    { "cd9e85f8-e7fb-4056-9e86-a288dd139881", "363d13ec-1280-402c-aafc-6b5fa4972704", "PurchaseType", "PurchaseType" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85015707-1d0b-4020-870a-c99dd896ec48", "AQAAAAEAACcQAAAAEE73XX0uhDjonxdh3trPCUFK1eZCfyhMuE8D84PA3+/wvkzDwEHFxlUHerVsqdbu/g==", "0c206729-f526-453c-8ed7-c722ae0dd912" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13db4ca9-3847-4ff0-afb6-8792a3844cb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23b9f195-9efa-4249-baa2-21f4e0241b9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2922c843-42d7-414c-8e75-3c6d4ff41a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a79d3b0-b86c-4610-bbf0-08ce903bf5e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da9d6b8-d8a9-4136-8757-a3ee6551a7ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458117b2-049d-4745-b403-457c74c34ac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f4d565-c15c-434b-8e16-6832143e66df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6963347a-3c97-4067-a25a-020b554d23e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf2b0db-235f-4852-931e-4814fa21398f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f470d75-8230-4f35-beb2-a74c495c546e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86144a8a-ba8e-44eb-98aa-44a14c42ccf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90181d29-4fb3-42d7-827d-6a3202e1e376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0b910d1-4d89-4ab6-af0a-de2e74dbf815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4efd654-286b-4bc5-9813-3b2beaa4f37d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac91ce43-4d87-4803-a7c6-f9adf952aac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c053a238-3bf3-4884-afc7-437231832702");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca24589f-fa06-4652-b33d-bec2a092d2b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9e85f8-e7fb-4056-9e86-a288dd139881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce85f325-e870-4835-8eaa-d914bb4a4d24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf99949a-1437-4ef5-8b65-49c3a897c985");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0577cce-bf19-4df1-b904-91e30428fe03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f10073f5-0e5e-482c-baf7-5fae98a0540a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a7c928-38e4-4d12-a9a8-fdc62eb41c35");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "296512bf-f15a-4499-bad6-1ef1a6cc1418", "178d75a8-83c0-4e3e-bf33-9f0214e4477b", "Product", "Product" },
                    { "e5c5026e-7425-42f2-9e76-b9e44510c4b9", "8ca3d417-1192-4098-acc7-f71399bbf898", "VendorType", "VendorType" },
                    { "e9aba7ee-c6fe-43d4-bf5b-9957fde39dc2", "b2b555b1-3e49-4686-aba6-d6cc43030a56", "PaymentReceive", "PaymentReceive" },
                    { "89c02269-dc40-4855-ab44-cab18c948831", "8cc734b7-856d-4266-91e3-6f8472454c27", "PaymentType", "PaymentType" },
                    { "95c36d81-36b8-4620-9404-7e28dde91525", "8db39d72-1458-441b-ade9-c680c67ae079", "Invoice", "Invoice" },
                    { "6363ea16-8ee3-4e8e-b552-c2fec0e805ee", "6932e7d4-26ff-4dbf-9ddf-9a2a719a9047", "InvoiceType", "InvoiceType" },
                    { "c38da81b-231b-4a17-85d7-532c788bc610", "e5cf780f-fd24-469f-ab54-9196599df9f9", "Shipment", "Shipment" },
                    { "87b70e94-598b-4844-97c8-117677b54d5e", "320eb04a-2baa-4165-b976-fa5b7e9a6978", "ShipmentType", "ShipmentType" },
                    { "2eb006d7-c828-483e-a5f6-3c45c33ce653", "6177adfe-48fa-49fb-b4c9-396fa2ff5b31", "ChangeRole", "ChangeRole" },
                    { "f0e4e0ac-7e8e-4e34-b174-17361c80f015", "0e921946-72a2-4ab5-bd47-6818643beb36", "User", "User" },
                    { "8cd89f28-784c-4d56-88f0-f72bad5c2daf", "b418e1b1-d57a-49f1-b92e-c82bc913b249", "Vendor", "Vendor" },
                    { "c31a9c08-20cf-4bdf-b4e0-f304ce6ac1fa", "42588133-09fb-450d-91c4-9b5fcb46d005", "Settings", "Settings" },
                    { "a2233469-9a4e-4dbc-89c8-2301e0f02c4c", "a199ca11-1ad8-4c1e-81ac-9be309d5af29", "Branch", "Branch" },
                    { "b8fc7e36-db55-4be5-acdd-8a3cdc03373c", "9b9a7909-07b7-4064-ab54-4b548c896f4b", "Currency", "Currency" },
                    { "d6368780-1374-48c9-be39-3eedebef0d43", "e40cadc6-a0f1-4b49-8a48-fd43b42cfafa", "UnitOfMeasure", "UnitOfMeasure" },
                    { "967502cc-b272-4c76-ba79-a0e7e555b145", "364109d2-8506-4d02-b11b-906dbfdcce06", "Category", "Category" },
                    { "de0216fe-8441-4f1a-b981-b8077ca48478", "8a13813a-611a-414d-b6d6-e0e99c9beaec", "SalesOrder", "SalesOrder" },
                    { "580d0db4-b0d2-408d-983e-0d6fbd1999f1", "d9613360-3f49-4b7c-99f4-19048e5816fd", "SalesType", "SalesType" },
                    { "016c3ff2-2ed6-4df2-a3bc-b4892c4c4b97", "e76401b2-78b9-4bcb-9886-4512efda9449", "Customer", "Customer" },
                    { "b7a767bb-4103-4824-b54c-ceb2a8ce97fa", "eb27dbbc-f7ae-404d-b5b5-777e2121a484", "CustomerType", "CustomerType" },
                    { "d4ff0382-9320-4565-bb25-25cd8f7e72a0", "79a9a369-2938-4d97-8323-7d5ce1f41c63", "Warehouse", "Warehouse" },
                    { "ec477481-5fa5-4b6a-9be2-323246d2fbd6", "c1ca34ca-5fc4-4b71-9cd7-76922282fac6", "Template", "Template" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4d68d6-ee68-488d-af48-c374783d1bc2", "AQAAAAEAACcQAAAAEOxL3HLCiK+AlXLNv5R8G0HAQ4F0uD+/h2s/eobXvWR1SBiB4uFE7bpeB2YGdaqZzg==", "25b6cf5a-9475-4e12-a363-087575fd6b64" });
        }
    }
}
