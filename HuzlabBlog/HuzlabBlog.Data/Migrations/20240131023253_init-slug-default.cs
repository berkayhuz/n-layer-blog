using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class initslugdefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("117c17ae-dff2-4914-b065-19a5c2954fe4"));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1023dafe-10a8-44c5-bb8b-d47e6ff77a4c"));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("117c17ae-dff2-4914-b065-19a5c2954fe4"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 31, 0, 35, 6, 601, DateTimeKind.Local).AddTicks(7425), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "05bb38d6-0371-41dc-8798-8cc4615c5b04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "ab1f87b5-999c-4ce0-9ae7-c0f21fd6c32a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "4c9d5dc6-a491-47fd-bd11-f870b7b46016");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32be0c5b-2be6-4781-9fc7-a6f5b229a12d", "AQAAAAIAAYagAAAAEOl8PGjloQgA6C1Q6zanYMXcOxaq7qVgw15bSkJsny1kt5l3biSScFlaoTPDWSJC5g==", "6122b025-9751-4bc9-bcf1-c9b386b3cadc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dfaf3e3-2c35-47a1-b13e-269167297b38", "AQAAAAIAAYagAAAAEHmym8DJWxJTasXqsNZXbvA0qZi8f6FN9OaikZjddbvhjGR7hZ5KqV/GEi5jBdXLsA==", "ea187867-2fc0-46d7-8c65-087ad1be1bd6" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 0, 35, 6, 602, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 0, 35, 6, 602, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 0, 35, 6, 604, DateTimeKind.Local).AddTicks(6600));
        }
    }
}
