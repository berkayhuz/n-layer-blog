using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class initemailsenderforregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1023dafe-10a8-44c5-bb8b-d47e6ff77a4c"));

            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationCode",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("1cb047ec-236b-4c55-bdc4-cc31d917a3e5"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 31, 6, 25, 53, 569, DateTimeKind.Local).AddTicks(9512), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "1c40d8ba-890d-4b48-b57a-7028f8eb031b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "aabdfdc8-4a8b-416f-99f8-5a9c9dff8ab2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "b97d420b-296c-4375-b28e-a7fc3710b6e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "EmailVerificationCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b356f71c-96d9-4559-8515-6c6312af4c7d", null, "AQAAAAIAAYagAAAAEJzZ2pkp2Hy6jaohIvypmRrZJX9068MAXrUOkpi3bstabzy1iTsX32P1FnbBRWAwzw==", "3cb44b1a-6701-4c64-82d5-3cd151a8fd78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "EmailVerificationCode", "PasswordHash", "SecurityStamp" },
                values: new object[] { "821de61d-9b82-4784-948b-e5d2e15d88c2", null, "AQAAAAIAAYagAAAAENOLw/0k4gGnAWI/6Z+gSFkX9azep9q8+3zV7RwLCTfIxq0RkQIJRQuq3VjJlRDc/w==", "265fe2b9-07f4-4a49-bb32-22a24490166c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 25, 53, 570, DateTimeKind.Local).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 25, 53, 570, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 25, 53, 572, DateTimeKind.Local).AddTicks(8076));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1cb047ec-236b-4c55-bdc4-cc31d917a3e5"));

            migrationBuilder.DropColumn(
                name: "EmailVerificationCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("1023dafe-10a8-44c5-bb8b-d47e6ff77a4c"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 31, 5, 32, 51, 709, DateTimeKind.Local).AddTicks(8964), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "195ac881-0025-46cd-af89-b95c67e7c75a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "55d748d5-1976-4c6e-9e13-9383f0621c94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "63afbe28-be29-4a59-825a-789ecee120be");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f313baf1-f9df-4f74-9fb5-ef3206e2ca78", "AQAAAAIAAYagAAAAEFpyWTVNze2fSIQEXnOob7a8xSaiz7l68pA4HiqU//tIFRUPfWrM4OihfkLn0pzqOA==", "dfafe264-0c2e-44af-864c-a98d59014d53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aee1025d-21dd-4f71-ac1f-957c185cc31b", "AQAAAAIAAYagAAAAENcVRM1P/T1yiAL7Fdn6FkeaprMDrGC8lQlyD8cf7iZqOVCjXPntAZGNVNZtGi8QmQ==", "645fd1cc-3c73-4ac7-8ada-70b26e705226" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 5, 32, 51, 710, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 5, 32, 51, 710, DateTimeKind.Local).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 5, 32, 51, 712, DateTimeKind.Local).AddTicks(8311));
        }
    }
}
