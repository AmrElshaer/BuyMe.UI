using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addVendorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d3d454-74e3-4445-9600-3ade329b60de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c915a66-25fa-4e1b-88d6-18cfd4cc1a85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55dea9a9-629f-4aa4-9d44-c28462ed4b53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5782c20f-860e-4eef-b553-b1f6712e012e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67e012df-fada-41e1-9f96-5ad42c3d95f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ca01494-b1be-4d28-98ac-ca158a2203c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a51cc9-6c45-4604-bf08-2c0fc571f8d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74ec27d1-d4b7-4be4-a1fd-4c565d36ce00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bfc019a-837a-49d0-9282-fdba5242ecce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97b3138a-1718-42c7-a07d-9f1095b0975e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a97a568-9ece-4320-b985-7c08c3c07290");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a368ad53-4126-4bea-82c5-3342bf38612d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a78f6b7d-d31a-468e-bbf4-334ccbffc310");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac36c870-9b38-44ea-8b3a-840b1ec0e9e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc4edbae-a049-4f7d-b00f-228b5e4e6e40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a4197a-d7bb-4d22-b0a9-7782a74e7f13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d905aa-78c6-4794-beeb-0c167a2e3fba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e061987b-2f17-4979-9e8a-279988006c47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f84de6-c118-4516-b8a4-4d02e16d714b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea17a18c-262e-4eb3-8fca-b0770964ce34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed2b99fe-9dbd-42df-950a-f50a73c6ca78");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "9a97a568-9ece-4320-b985-7c08c3c07290", "364cd877-57e2-4f41-99a9-2b9ff6484d1f", "Product", "Product" },
                    { "6ca01494-b1be-4d28-98ac-ca158a2203c4", "c631b53b-e9cf-4272-bd39-63cf5dd69987", "PaymentReceive", "PaymentReceive" },
                    { "ac36c870-9b38-44ea-8b3a-840b1ec0e9e2", "eaba2cc4-3a62-4296-b8f6-9483e6b15049", "PaymentType", "PaymentType" },
                    { "27d3d454-74e3-4445-9600-3ade329b60de", "5d24457c-5c7b-43ac-99ef-4c253e25ce82", "Invoice", "Invoice" },
                    { "d5d905aa-78c6-4794-beeb-0c167a2e3fba", "b0e36aea-d03b-4f28-97a9-5e40fbf142e9", "InvoiceType", "InvoiceType" },
                    { "71a51cc9-6c45-4604-bf08-2c0fc571f8d0", "468415d6-aa03-4854-9cb3-d24994f81736", "Shipment", "Shipment" },
                    { "67e012df-fada-41e1-9f96-5ad42c3d95f8", "c09f709e-6555-4a53-89a9-651d0b8c5c2b", "ShipmentType", "ShipmentType" },
                    { "a368ad53-4126-4bea-82c5-3342bf38612d", "f9ec0408-769d-4168-808c-7cf4093a2199", "ChangeRole", "ChangeRole" },
                    { "7bfc019a-837a-49d0-9282-fdba5242ecce", "c902d3af-1f51-48da-b0f0-e643e8f6a09a", "User", "User" },
                    { "3c915a66-25fa-4e1b-88d6-18cfd4cc1a85", "aea29674-b146-498f-b8eb-a8fa49518e55", "Settings", "Settings" },
                    { "ed2b99fe-9dbd-42df-950a-f50a73c6ca78", "1a019369-022b-4748-9982-6f4e562bbab5", "Template", "Template" },
                    { "e061987b-2f17-4979-9e8a-279988006c47", "88313d81-98a3-4414-99d8-91bab4a0639d", "Branch", "Branch" },
                    { "74ec27d1-d4b7-4be4-a1fd-4c565d36ce00", "0fc62b68-03c3-4ad5-b7d3-37fab0441f19", "Currency", "Currency" },
                    { "97b3138a-1718-42c7-a07d-9f1095b0975e", "97d38ce6-a0ea-422d-840d-249e7df94a9a", "UnitOfMeasure", "UnitOfMeasure" },
                    { "e8f84de6-c118-4516-b8a4-4d02e16d714b", "50fa7e9a-fd47-4712-878f-3cfd28e634bb", "Category", "Category" },
                    { "5782c20f-860e-4eef-b553-b1f6712e012e", "9d02cb24-6c9f-4ae1-9b96-89a100e9f21f", "SalesOrder", "SalesOrder" },
                    { "c5a4197a-d7bb-4d22-b0a9-7782a74e7f13", "100f93e1-fc52-488b-aa64-fbfb0dbbd70b", "SalesType", "SalesType" },
                    { "bc4edbae-a049-4f7d-b00f-228b5e4e6e40", "731e39d2-9c33-4410-b48b-334e7110d8c1", "Customer", "Customer" },
                    { "55dea9a9-629f-4aa4-9d44-c28462ed4b53", "4ea5b1d7-b842-4034-833f-7dd0412a8711", "CustomerType", "CustomerType" },
                    { "a78f6b7d-d31a-468e-bbf4-334ccbffc310", "887a3742-f9f1-4408-8681-3b4b3bc9946d", "Warehouse", "Warehouse" },
                    { "ea17a18c-262e-4eb3-8fca-b0770964ce34", "dfd65496-ce25-4f3a-9049-cb559b55a98e", "VendorType", "VendorType" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f21224-5076-4cbd-b090-94de95fcbcde", "AQAAAAEAACcQAAAAEHiw1pMhtaM++s3eg7R1uME8phTJMD/3QKBhnU3GYmAJpP0pRHMjQbCf1u1ieJUKPQ==", "344f712a-7e86-4f90-9634-ea86ef8eae6d" });
        }
    }
}
