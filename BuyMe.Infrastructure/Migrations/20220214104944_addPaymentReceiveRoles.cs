using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addPaymentReceiveRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "065e3704-0c07-463e-a614-6ebd0260c0ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1117df6e-4501-4cea-8af2-29a81924585c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37eb20ea-ffa1-480b-bdd6-f644772826d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3980cda9-c01d-42ec-a5af-ec421238cfe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a4ecf92-977d-4e97-9d1e-0ec7f6c0cc0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be54acd-6ce1-4ec7-831a-2b674e81494c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed9525e-95e2-4e7f-b9e6-01b5ced029dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6149a375-f345-47c9-a1df-f2f789f9878c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "658da837-373d-4ca1-9619-45930ad44779");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68bcd706-de81-4ee7-910d-b9c97829ec5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a197fb2-b52e-4c1f-9ff2-dcdbbb70ec5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "734f61c7-e748-43bd-b102-a7aa7dd6ded2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b290aa-4b6e-48ed-a53e-e20bfed236eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e5c575d-17b0-4cfd-948c-327408ec3c9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38d21ae-bbb8-415d-9a3c-82afb3260c46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf64eac8-6830-4f86-9b31-3c1391401bca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd2eb744-bbf5-436c-af1c-e70d32c0734e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e47228c2-f379-4b93-b444-1788e62df851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa49468a-d813-4c83-ac57-c0d9fbc93f46");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "bf64eac8-6830-4f86-9b31-3c1391401bca", "d17f877a-0ba5-4eed-b2c5-1f2b1c03234a", "Product", "Product" },
                    { "6149a375-f345-47c9-a1df-f2f789f9878c", "ff7f3aec-cc24-4002-a869-a0653960ad29", "Invoice", "Invoice" },
                    { "5be54acd-6ce1-4ec7-831a-2b674e81494c", "87d5a8bf-093b-426b-a5ce-6ed9e5b545b1", "InvoiceType", "InvoiceType" },
                    { "86b290aa-4b6e-48ed-a53e-e20bfed236eb", "7cd43f4e-0149-4886-af9a-039af7e2a098", "Shipment", "Shipment" },
                    { "fa49468a-d813-4c83-ac57-c0d9fbc93f46", "bfbc20a4-60a8-4f1c-b57e-5fc5cffcd498", "ShipmentType", "ShipmentType" },
                    { "3a4ecf92-977d-4e97-9d1e-0ec7f6c0cc0a", "ee312309-fb2e-49d3-9198-761006e41955", "ChangeRole", "ChangeRole" },
                    { "065e3704-0c07-463e-a614-6ebd0260c0ce", "65233aa3-fa31-4f18-b4a4-e5a704844cc4", "User", "User" },
                    { "5ed9525e-95e2-4e7f-b9e6-01b5ced029dd", "c8f87c12-7518-4a3f-bd71-41a7c2b3f533", "Settings", "Settings" },
                    { "8e5c575d-17b0-4cfd-948c-327408ec3c9c", "a9037fc4-6eae-4c70-bac5-b065420a0675", "Template", "Template" },
                    { "3980cda9-c01d-42ec-a5af-ec421238cfe2", "07e921f4-2595-4661-98a9-bdb81b65cef7", "Branch", "Branch" },
                    { "b38d21ae-bbb8-415d-9a3c-82afb3260c46", "b9aa62b5-9aeb-4713-bd1f-794b5cdae9f7", "Currency", "Currency" },
                    { "68bcd706-de81-4ee7-910d-b9c97829ec5d", "99af9e03-5868-4c2c-a6b9-235e0f8dbda5", "UnitOfMeasure", "UnitOfMeasure" },
                    { "6a197fb2-b52e-4c1f-9ff2-dcdbbb70ec5a", "5008226d-5031-4b81-8ce1-ccd9daf13768", "Category", "Category" },
                    { "734f61c7-e748-43bd-b102-a7aa7dd6ded2", "ca8f51bd-b068-4eb7-ac1f-320f1e967238", "SalesOrder", "SalesOrder" },
                    { "e47228c2-f379-4b93-b444-1788e62df851", "fe55f07a-a1fd-4881-9f3d-7d583fcb53ca", "SalesType", "SalesType" },
                    { "658da837-373d-4ca1-9619-45930ad44779", "b5588eb0-7453-4858-8b92-42ebc84dac44", "Customer", "Customer" },
                    { "37eb20ea-ffa1-480b-bdd6-f644772826d7", "f10af21a-c8f7-44fc-aa8a-ae974079c5a3", "CustomerType", "CustomerType" },
                    { "dd2eb744-bbf5-436c-af1c-e70d32c0734e", "04d90a4f-05d6-4309-a1ce-6b6a5e550e74", "Warehouse", "Warehouse" },
                    { "1117df6e-4501-4cea-8af2-29a81924585c", "4c0334e9-cf63-4dfb-a35d-75f7fb966c02", "PaymentType", "PaymentType" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64c8f848-17ba-47d7-8b52-cc611dc5115f", "AQAAAAEAACcQAAAAEKydIpadrfxcE4MhwBByitWBrQG6a3FomcD3GOOYzTNo9kEBtD9OiDQ6rVdLNwFNfA==", "08d87ff5-2182-4bd8-b621-7b27045d2365" });
        }
    }
}
