using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class init_28_01_2024_user_biography : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c4395db2-5ad1-4a4b-be06-07a64853c688"));

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("692e04e6-b29d-4547-9680-2f5678d5b155"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 28, 4, 22, 22, 789, DateTimeKind.Local).AddTicks(1133), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "27949c61-f434-4f07-a088-12afaf3f7968");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "2f518169-9f6d-4a48-9ac2-5a0eccb30551");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "5a8593cc-3984-425f-ad83-9a46300473a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "Biography", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Biography 2", "4f47b190-ec53-40b5-9ff6-dce9411921bc", "AQAAAAIAAYagAAAAEOHJrb6mmosS0iDdMqo0p+gl1PN1oCi8lMjf9KlAb70THC3fwOEXTjMcKgjq4EfcFQ==", "ad2c5f0e-fab3-4856-a4ff-7ce9eb1d2160" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "Biography", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Biography 1", "6cb42412-2765-4262-83e5-3e53d36c018b", "AQAAAAIAAYagAAAAEM5L2eUaeHNfQDSG1OdBL1cr0p1uxnG08m2wN7/DskwKJLvlGtYtKrrH3kj21lAx5Q==", "bbbe1a45-a120-4f3a-bac7-73da425f12ed" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 4, 22, 22, 790, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 4, 22, 22, 790, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 4, 22, 22, 792, DateTimeKind.Local).AddTicks(3171));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("692e04e6-b29d-4547-9680-2f5678d5b155"));

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("c4395db2-5ad1-4a4b-be06-07a64853c688"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 28, 2, 2, 42, 773, DateTimeKind.Local).AddTicks(2457), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "5381f60e-ab4f-4865-847c-fb3f835455af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "8ea2cce3-5d71-48ff-954b-d75b80843660");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "b043d60c-3794-411c-9259-8cdb5167649d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6f0da08-f4fc-482a-bdc2-f39b6be00695", "AQAAAAIAAYagAAAAEEcjw010Fro+8BukzxvbrCNQ4kB+6g7BUZ3jA8uVaTv9y/nkKyO29ibh/CGqbaGR/A==", "c01e7d2a-7876-4555-992b-c22b1be231d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c73f69b8-1ca2-40fa-ae34-1fe7eb48fa94", "AQAAAAIAAYagAAAAEGEysyVzRMJ5H2ewDpiTDH2O4XqVzS551eto+B5ePoi7+CEuzHCo7nOfugqtPewKQQ==", "03cecac6-1727-4fa6-8d39-26f2d7962448" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 2, 2, 42, 774, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 2, 2, 42, 774, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 2, 2, 42, 777, DateTimeKind.Local).AddTicks(335));
        }
    }
}
