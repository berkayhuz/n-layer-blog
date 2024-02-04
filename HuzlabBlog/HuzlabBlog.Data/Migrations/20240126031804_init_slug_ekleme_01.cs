using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class init_slug_ekleme_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("eaba5bda-b693-4b85-aae5-0a9ca9d619ec"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 26, 6, 18, 3, 693, DateTimeKind.Local).AddTicks(5516), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "c044e681-4eaf-4856-9e19-fd8c12387026");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "cbb65194-3681-43ec-b575-429dd33d76ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "4ac67cf5-e351-4393-ae24-f38e3f538a24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Slug" },
                values: new object[] { "2d1e0836-a94d-45e0-b9a1-15b774b42598", "AQAAAAIAAYagAAAAEAhMT0toIRm41cY2dfcSIgLZ/XZnDuWSAR1uVCYjC7kkqDd+EHNi5QT+HN9Z0+S4Yg==", "1aef0f69-51e2-49be-b647-a30b601989e6", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Slug" },
                values: new object[] { "c36506c0-dd6c-456a-8e40-100127717051", "AQAAAAIAAYagAAAAEEJu9E2e3n4ZjTAvoG3aEP0MAr13iC4KLMw3o1LS82tWTbMSI8NVgXO2cytT8q37ZQ==", "5c3dfbc5-1e6e-4a00-af22-e1c3de7f2f58", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 26, 6, 18, 3, 694, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 26, 6, 18, 3, 694, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 26, 6, 18, 3, 696, DateTimeKind.Local).AddTicks(6175));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eaba5bda-b693-4b85-aae5-0a9ca9d619ec"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "AspNetUsers");

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
                column: "CreatedDate",
                value: new DateTime(2024, 1, 26, 6, 16, 24, 455, DateTimeKind.Local).AddTicks(6993));

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
    }
}
