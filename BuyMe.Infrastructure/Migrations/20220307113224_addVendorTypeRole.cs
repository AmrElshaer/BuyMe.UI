using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addVendorTypeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060b3c12-4560-4b2a-b62e-17e65841d3a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0923bef0-96a4-4593-b633-42bc94c2dd45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c6e7952-2ebf-4373-aead-53378e0d377c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "393b9f3c-6e64-4294-b3b4-e856fbe93623");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40504114-7e1d-4894-9ad5-982683face17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "541b670e-8016-4bba-a7a1-17479db8932c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55e4cb9d-9829-4d46-a89d-d549175f28f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "646b3815-e166-4fd7-a9d6-c9180edcee5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "683c8b26-7545-448d-be2e-7dc90195c386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "812b1384-6bd8-4ad7-8687-7966c06bdccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bd5415-d3d9-49f7-b0e7-fad668b49d43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9712fe49-eba2-44e0-a3bc-463a9f3b6a2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a1ee1b2-8264-42db-90fd-75d89ab4e316");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beb25da1-09c2-49e9-9132-000b4fb8ada9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c27cc7c6-4c1c-4e39-b0c3-54095c015065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca77057d-430d-4907-95a0-0754efa917df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df2da320-f82f-440b-8eaa-59ca7f8a3be6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e63f84-5c4a-4564-901a-f18aacdd9085");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e856c4ad-e64f-42e1-8776-55c4d6835961");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3111c47-4934-42bd-a8c9-da6e88e5d943");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "683c8b26-7545-448d-be2e-7dc90195c386", "3aaed087-5db9-4882-bbd7-cb631fbb64e4", "Product", "Product" },
                    { "40504114-7e1d-4894-9ad5-982683face17", "3e5d6e6b-583a-400c-a488-11266044768c", "PaymentType", "PaymentType" },
                    { "0923bef0-96a4-4593-b633-42bc94c2dd45", "20c86aec-ff4e-44f7-85fc-bc56d14ce823", "Invoice", "Invoice" },
                    { "beb25da1-09c2-49e9-9132-000b4fb8ada9", "94886d04-5b88-48bf-afba-489c264dddb8", "InvoiceType", "InvoiceType" },
                    { "e856c4ad-e64f-42e1-8776-55c4d6835961", "e02cc54d-2d48-4582-97b8-c52404e3cbd2", "Shipment", "Shipment" },
                    { "541b670e-8016-4bba-a7a1-17479db8932c", "88ecf8b4-4013-491f-b41f-131567aebdca", "ShipmentType", "ShipmentType" },
                    { "81bd5415-d3d9-49f7-b0e7-fad668b49d43", "558ec506-6b18-409f-b713-4dec38815180", "ChangeRole", "ChangeRole" },
                    { "812b1384-6bd8-4ad7-8687-7966c06bdccf", "e424f150-9490-43cd-88dd-0a7dd6f15716", "User", "User" },
                    { "c27cc7c6-4c1c-4e39-b0c3-54095c015065", "7cbf9c5b-2620-4664-8e28-227d8797a641", "Settings", "Settings" },
                    { "9712fe49-eba2-44e0-a3bc-463a9f3b6a2c", "23df2e7d-1716-4db7-861a-ddc50a8b8979", "PaymentReceive", "PaymentReceive" },
                    { "9a1ee1b2-8264-42db-90fd-75d89ab4e316", "967ad6ff-cf32-41cf-8be2-b185d18627c4", "Template", "Template" },
                    { "f3111c47-4934-42bd-a8c9-da6e88e5d943", "f26402d1-3dbd-4140-b4f3-dd38ff65df1b", "Currency", "Currency" },
                    { "55e4cb9d-9829-4d46-a89d-d549175f28f3", "3a3d5605-e00f-4d27-8073-1a1877a83976", "UnitOfMeasure", "UnitOfMeasure" },
                    { "646b3815-e166-4fd7-a9d6-c9180edcee5d", "5ffd2288-7ca9-491c-b8db-a21e5b299e9b", "Category", "Category" },
                    { "e3e63f84-5c4a-4564-901a-f18aacdd9085", "fc8f4e4f-561d-442d-937e-a43f237385db", "SalesOrder", "SalesOrder" },
                    { "ca77057d-430d-4907-95a0-0754efa917df", "ecac3c5f-f668-4912-86b4-c3e9fe9a7eba", "SalesType", "SalesType" },
                    { "393b9f3c-6e64-4294-b3b4-e856fbe93623", "2e1396e0-69fd-40b0-af96-db1dd07f38e0", "Customer", "Customer" },
                    { "0c6e7952-2ebf-4373-aead-53378e0d377c", "326dddd7-35cc-446c-9bd9-8f98bfcbc6ce", "CustomerType", "CustomerType" },
                    { "060b3c12-4560-4b2a-b62e-17e65841d3a0", "7c4836af-674e-4b0f-99bc-0b842abbca27", "Warehouse", "Warehouse" },
                    { "df2da320-f82f-440b-8eaa-59ca7f8a3be6", "2b7c8cb7-eec8-4be7-a3a1-72480fc021e1", "Branch", "Branch" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84673685-affc-491a-a738-7ca37bae3a30", "AQAAAAEAACcQAAAAEC6oDeIFwIJr8gHbrN75egipDVSqiVvcT/U5nZ3/WKTkufy3H7EPd+tyV9WjiY2LdA==", "530faf8e-cdba-47d0-a700-b32a1688c11e" });
        }
    }
}
