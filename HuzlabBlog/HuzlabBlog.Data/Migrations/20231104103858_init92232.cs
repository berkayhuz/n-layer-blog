using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class init92232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9e978e32-ccca-484d-a177-5cca213026bf"));

            migrationBuilder.AddColumn<bool>(
                name: "IsEditorChoosed",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("315517e0-080e-4d05-82e4-28c44f685251"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2023, 11, 4, 13, 38, 57, 573, DateTimeKind.Local).AddTicks(1941), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "03a48647-737c-4018-91fc-031ad7f9e8c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "3f2215ae-3308-4671-92c8-44ad7873e6a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "0f378a5a-192d-45ad-8d66-3df19102bdfb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85ff505c-ffa0-4230-a852-6f8c9def8199", "AQAAAAIAAYagAAAAENfLGGuFSYn8JWs9oNZ60hRwQsOM3Nf2A/LTigb9TdB79hOMENyoDx5BoIhahYUiQQ==", "1e014bf1-8eb9-410b-b096-a3444dd0fc74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5d6ca70-5da2-4532-8284-a31118a24bf1", "AQAAAAIAAYagAAAAEN/fhb88Z2rtA/T8/npZQClqLA7xifenhL5opZmIb8mQfulzcVJIJxKZtlHVadEWXg==", "a7fab152-5d65-41bf-98d9-e9219887e05a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 13, 38, 57, 573, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 13, 38, 57, 574, DateTimeKind.Local).AddTicks(1437));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("315517e0-080e-4d05-82e4-28c44f685251"));

            migrationBuilder.DropColumn(
                name: "IsEditorChoosed",
                table: "Articles");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "779b06e5-e5b5-43db-b8dc-c848546a8ed7", "AQAAAAIAAYagAAAAEJBBFieB0I38bjweIXxp+M5I34eUzvIsOpH6lZEIgr/KaUxmjWctjzjLN019FzLqWg==", "5956b018-3b97-45e4-af78-b3b2157e599f" });

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
    }
}
