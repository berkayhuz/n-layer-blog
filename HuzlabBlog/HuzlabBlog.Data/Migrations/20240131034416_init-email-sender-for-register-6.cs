using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class initemailsenderforregister6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0011dc00-390d-4118-bf71-d4b266f77e76"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("ae077ae8-9ec8-4dae-b6ca-e20bcf7e9ed9"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 31, 6, 44, 15, 174, DateTimeKind.Local).AddTicks(5647), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "44e28871-3c60-4c56-ba5a-adcdf790957a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "6530ff94-7878-40bc-92bc-26af9bc58e7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "de022998-b161-4bb0-a527-c59b636cbdda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "599e2d57-fca3-436e-9b09-e3e94342837c", "AQAAAAIAAYagAAAAEOEsK+WKHQDyZNDEYx007xLe+jtJXOU8Bc8uTezit2MHFuLXuUElQWQIL9+bSPEUvQ==", "11410705-8204-4971-8ee0-83136d510927" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c564f8-10e7-458d-acb6-f62258993346", "AQAAAAIAAYagAAAAEM76Ygl8kzEGr9tKSTt9vmprTmbj+cwrCooR4Xvivtjt9IAqCRAeooQFNlhPAdLWKg==", "aa754e69-d859-4b4a-a356-615716294b60" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 44, 15, 175, DateTimeKind.Local).AddTicks(9572));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 44, 15, 176, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 44, 15, 178, DateTimeKind.Local).AddTicks(5636));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ae077ae8-9ec8-4dae-b6ca-e20bcf7e9ed9"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("0011dc00-390d-4118-bf71-d4b266f77e76"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2024, 1, 31, 6, 41, 3, 315, DateTimeKind.Local).AddTicks(6365), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "asp.net-core-deneme-makalesi-1", "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "ab1e3e26-8720-4ff5-98dd-b105d0cb5838");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "7ddcca1f-f99c-4f02-b213-d96a3b900cea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "5faaee9e-d7d9-4762-b1a2-2420b071e38f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b493fc8-3b07-4fd8-8298-ee41a5ee8a15", "AQAAAAIAAYagAAAAECE0Zk4x2N6M0F5/Z90uUMhyztLc4pfzyKxpmK9RnxGEywUZBk9ZlIZAxmkD80LTlg==", "c1ecbb60-dcdb-4e83-af4b-36af1bc804ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "098d239b-7a8e-4f5a-8d3b-111eedd61dbe", "AQAAAAIAAYagAAAAEDqTie8Hhk6qrt8QHn22W6UVxnwc2H7UQN/09V/1O2tb4j0pmryI7LaX6mr0w4lTZQ==", "10fdc5f9-d4e6-4060-b410-b9d90dd09e35" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 41, 3, 316, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 41, 3, 317, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("025ee5d2-1c37-486d-a441-ea7764629da5"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 31, 6, 41, 3, 319, DateTimeKind.Local).AddTicks(1762));
        }
    }
}
