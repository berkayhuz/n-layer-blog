using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class sdmkkmds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2ec94c0a-3aa9-4dc8-9c73-970a9adf0c1c"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlider",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsSlider", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("9e978e32-ccca-484d-a177-5cca213026bf"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2023, 11, 3, 15, 36, 28, 158, DateTimeKind.Local).AddTicks(8831), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "3b22c236-65a9-4736-8e60-8dd13283ad51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "396d57ca-6c7d-4907-bfd0-fd8a4820267b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "db51d9ea-8d9f-4918-8468-fd2ffd647473");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "779b06e5-e5b5-43db-b8dc-c848546a8ed7", "deneme@icloud.com", "Deneme", "Deneme", "DENEME@ICLOUD.COM", "DENEME@ICLOUD.COM", "AQAAAAIAAYagAAAAEJBBFieB0I38bjweIXxp+M5I34eUzvIsOpH6lZEIgr/KaUxmjWctjzjLN019FzLqWg==", "5956b018-3b97-45e4-af78-b3b2157e599f", "deneme@icloud.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3deeb6cb-cef2-4644-988b-a55f5644028b", "AQAAAAIAAYagAAAAEI3e4AnkSsDYn7AE2uc4UDZf4Frb/Yi419fI3/cEZYY6B+zC5n+Cw/ApZ/97zUBdIA==", "e1b3b218-3028-43c9-b573-917fc0076032" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 15, 36, 28, 159, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 15, 36, 28, 159, DateTimeKind.Local).AddTicks(8484));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9e978e32-ccca-484d-a177-5cca213026bf"));

            migrationBuilder.DropColumn(
                name: "IsSlider",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("2ec94c0a-3aa9-4dc8-9c73-970a9adf0c1c"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2023, 11, 2, 17, 38, 12, 926, DateTimeKind.Local).AddTicks(6679), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "e6b73cb0-4e68-4817-acb1-89ef0ec5ad97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "8e196bd1-c3b2-45bf-aaf2-4899f27c9d88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "e4d49cbd-2729-42eb-864c-2f9dc2e27227");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "562c2199-e7b2-48b6-b641-41f6b218801c", "hephizlimine@icloud.com", "Mine", "Hephızlı", "HEPHIZLIMINE@ICLOUD.COM", "HEPHIZLIMINE@ICLOUD.COM", "AQAAAAIAAYagAAAAEEPos4H/1f0I/ygJRHDis6Ssl2RiJFiqPSkzKKFv/bIi6UQiJBNuSi+SGkrrdhSb4Q==", "05764baa-21ac-4cc1-b901-0fe77bed1ac3", "hephizlimine@icloud.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0572e551-68e4-4760-86dd-fe2593f7cb7c", "AQAAAAIAAYagAAAAEM9b019bAjjDTRdiwmBmbIOSLmX8zl8oFtAjrCxIOqE19c9qRGd4zyo8rubBYsk3BA==", "fe2f0b19-5a51-4a68-a5b2-441cf27e9a16" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 2, 17, 38, 12, 928, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 2, 17, 38, 12, 928, DateTimeKind.Local).AddTicks(6411));
        }
    }
}
