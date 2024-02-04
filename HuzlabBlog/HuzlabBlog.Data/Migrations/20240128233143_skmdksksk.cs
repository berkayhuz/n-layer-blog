using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class skmdksksk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("33a29589-3df2-4fa8-9182-e68389b21f31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f29-bd4a-9d95b601316b"));

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "99eb49ff-431c-4439-b105-1e087945d9b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "4f8c3e5d-834d-464a-a9b7-02675e17088f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "b9dbc23f-858a-40be-9ffd-aa66cb790a0d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3a0e79a-d547-4163-a87a-5642f2f2ccbf", "AQAAAAIAAYagAAAAENEBS9EKlngmMxumIf41/OU3kNfax4UPUz2FKzZlnnLxD1x7cCc8mk/EYqW+VG+Nyw==", "18d3f8b2-2711-41ec-964b-9a23398e2037" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 0, "Biography 1", "f4a31636-0ad7-4616-a0ab-3e42dc69cfd2", "huzberkay@icloud.com", true, "Berkay", new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), "Huz", false, null, "HUZBERKAY@ICLOUD.COM", "huzberkay@icloud.com", "AQAAAAIAAYagAAAAEIglNBQKyhdlar9qaNMEDYvy0dwalArWiFyDv2guBhSQMEu+Tsl13gw6d9fPFRXlDg==", "+905438018574", true, "6a93cc25-f288-46ef-bded-5e8dfcc974db", "berkay-huz", false, "huzberkay@icloud.com" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 2, 31, 42, 105, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 2, 31, 42, 105, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 2, 31, 42, 107, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("381f736a-e0fd-4c69-a636-8c253f4daf13"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 29, 2, 31, 42, 104, DateTimeKind.Local).AddTicks(2949), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("381f736a-e0fd-4c69-a636-8c253f4daf13"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"));

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("33a29589-3df2-4fa8-9182-e68389b21f31"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 29, 1, 3, 35, 95, DateTimeKind.Local).AddTicks(4161), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "0951d37e-8d01-4c80-918d-b55d8bb79d89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "81ab1b81-d90e-4df0-bbd5-e54579531716");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "7157332e-a99c-43b1-aae3-3cce2b73e3de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "657dea83-5fc3-40e6-ac36-007d73ee408c", "AQAAAAIAAYagAAAAEHLAxayIO/8U1hYr5zEhBpM8oahzrd/AnRthq9RcVIADAS5yFHjLrvBYRK1QNZ3CXA==", "644e0d50-42b8-4dbb-83f3-f57c2723783e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b3402ec4-ab10-4f29-bd4a-9d95b601316b"), 0, "Biography 1", "9452ee11-8f4f-451a-aae7-b51c8007879b", "berkay_huz@hotmail.com", true, "Berkay", new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), "Huz", false, null, "BERKAY_HUZ@HOTMAİL.COM", "berkayhuz", "AQAAAAIAAYagAAAAEIVVy/3MJ2ja3mkEnc2AMgMioyTfk1vNB1z6WuM9H3nlPda5gQLax1stHbY7Xcskkw==", "+905438018574", true, "a3b4bcda-2808-499c-a302-8662a927c66f", "berkay-huz", false, "berkayhuz" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 1, 3, 35, 96, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 1, 3, 35, 96, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 1, 3, 35, 98, DateTimeKind.Local).AddTicks(5403));
        }
    }
}
