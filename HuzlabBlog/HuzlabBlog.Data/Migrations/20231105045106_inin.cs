using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuzlabBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class inin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("315517e0-080e-4d05-82e4-28c44f685251"));

            migrationBuilder.AddColumn<string>(
                name: "MiniDescription",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsEditorChoosed", "IsSlider", "MiniDescription", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[] { new Guid("26a08cda-b297-4b4a-bfc6-4d3d686dfb2c"), new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"), "Deneme Content", "Berkay Huz", new DateTime(2023, 11, 5, 7, 51, 5, 995, DateTimeKind.Local).AddTicks(9171), null, null, new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"), false, false, false, "Deneme Description", null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"), 15 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68dfdd6b-a20b-498c-ad1d-b0eb12ae076a"),
                column: "ConcurrencyStamp",
                value: "4599e3ae-6fa7-4946-82e0-96d8ae7873a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c1bd465-4ff6-437e-b43e-1f848fd26d99"),
                column: "ConcurrencyStamp",
                value: "b5b07992-8746-4c66-b9e9-c5a7f9d3620f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cad1bc04-44bf-44b7-ade1-4d6b3fffcba7"),
                column: "ConcurrencyStamp",
                value: "014eb793-5841-44a0-b371-20cbe11e5a9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31feb16f-8c01-4e22-9a6f-df79b7e5582a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "354d528e-3caa-4b12-95b1-6d894a3ebbc0", "AQAAAAIAAYagAAAAEGjYrQrRAcYFnWhrE42bhyk0GiNqL1TutE0bNwiEkljnlSwuGYarMzl49hzXKZ7Yjg==", "5b983e7c-9484-4a56-8df8-d53c209a7d74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3402ec4-ab10-4f89-bd4a-9d95b601316f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd451584-4cad-4ae8-b842-20f235cc4314", "AQAAAAIAAYagAAAAEEoCQxNS5NxEDUfgtrraEkh45dl4CSw1LDFICID1Q60fjXEJKoeHYDlVRFVDAiYW0Q==", "f3efcc48-03ec-45c6-b8b7-2c2a34be1aeb" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f679be0-ca72-4dfc-b2bf-66e375f9cbc0"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 7, 51, 5, 996, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5783a0a4-0c35-4f26-a466-05636f9fee2c"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 7, 51, 5, 996, DateTimeKind.Local).AddTicks(9187));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("26a08cda-b297-4b4a-bfc6-4d3d686dfb2c"));

            migrationBuilder.DropColumn(
                name: "MiniDescription",
                table: "Articles");

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
    }
}
