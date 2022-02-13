using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyMe.Infrastructure.Migrations
{
    public partial class addPaymentRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
