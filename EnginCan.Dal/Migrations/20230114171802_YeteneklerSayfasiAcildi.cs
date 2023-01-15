﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnginCan.Dal.Migrations
{
    public partial class YeteneklerSayfasiAcildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[] { 16, "Yönetim Paneli / Yetenekler", "/yonetim/yetenekler", null, null, false, "fa fa-list", true, "Yetenekler", (short)1, 1, "/yetenekler", null });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[] { 16, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 16, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PagePermissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "AllName", "AllRouterLink", "Color", "Description", "HomeWidget", "Icon", "MenuShow", "Name", "Order", "ParentId", "RouterLink", "WidgetIcon" },
                values: new object[] { 15, "Yönetim Paneli / Hakkımda", "/yonetim/hakkimda", null, null, false, "fa fa-address-card", true, "Hakkımda", (short)1, 1, "/hakkimda", null });

            migrationBuilder.InsertData(
                table: "PagePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedUserId", "DataStatus", "Forbidden", "LastUpdatedAt", "LastUpdatedUserId", "PageId", "RoleId", "UserId" },
                values: new object[] { 15, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, null, 15, 1, null });
        }
    }
}
