using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class init_slug_ekleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a6e537e3-428d-400f-bf25-1ec1b19690fc"));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("f74ca261-6d6e-4e7e-99f1-50bc1b9d8f45"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 26, 6, 16, 24, 454, DateTimeKind.Local).AddTicks(7507), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "bb3b284c-1fda-4aaa-a405-3da3a637a87b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "7e71d632-c51d-4ae4-ab2d-51c9c499a841");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "c198f391-1418-466c-9ed6-b1cb82386228");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "110edb06-94e1-4147-ad7e-1e45aed368ca", "AQAAAAIAAYagAAAAEPC6vSN2WkPUmUsHFMGJZM6AiMuK4y1KK1s8xLau7TMQPuKoGNcgZkkLqJ1B09A6iw==", "4eefcd51-c115-435c-a8d8-eb768dd46ce8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44734b2b-5381-484c-af72-b677d80a583f", "AQAAAAIAAYagAAAAEMTelRRB1K8uyn/CrDkIDEJa+m3t/kmi5IPvh+h9qFhh55ws9pmDETSKoDUqQxithA==", "2aa56084-8d57-4dc4-b4f1-141b25e55cf8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                columns: new[] { "CreatedDate", "Slug" },
                values: new object[] { new DateTime(2024, 1, 26, 6, 16, 24, 455, DateTimeKind.Local).AddTicks(6993), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                columns: new[] { "CreatedDate", "Slug" },
                values: new object[] { new DateTime(2024, 1, 26, 6, 16, 24, 455, DateTimeKind.Local).AddTicks(8722), null });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                columns: new[] { "CreatedDate", "Slug" },
                values: new object[] { new DateTime(2024, 1, 26, 6, 16, 24, 458, DateTimeKind.Local).AddTicks(2146), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f74ca261-6d6e-4e7e-99f1-50bc1b9d8f45"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("a6e537e3-428d-400f-bf25-1ec1b19690fc"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2023, 11, 5, 8, 22, 35, 574, DateTimeKind.Local).AddTicks(6688), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "f06ab16a-1a24-485c-9695-b77f3ff178f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "5631a29a-4f3d-4440-8f7c-1eb63cb9a013");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "1b878c48-2e4e-4011-af00-3b93c5b3ace3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e07ab74-6e54-43bb-8a7c-f4c6d1e52af1", "AQAAAAIAAYagAAAAEM/a4SNjTD40TYkvNut2HyOoDa5BY+WohneT8uOjzRkpQa2R5tCBZDl+RHSnRUH9QQ==", "58936a26-ff2d-4790-a9c3-917549a1c703" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f94dfab7-b01f-4be0-892e-c3f9d489f6bf", "AQAAAAIAAYagAAAAEGPgs17+YnKHtDSVH48Rya5Zq6BtLZpWnRncH0ZtlIvFi0UM35LfSrA0+25PY3dNaw==", "6ee4b371-ac08-4f6e-bc28-db57f57fb420" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 8, 22, 35, 575, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 8, 22, 35, 575, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 8, 22, 35, 578, DateTimeKind.Local).AddTicks(308));
        }
    }
}
