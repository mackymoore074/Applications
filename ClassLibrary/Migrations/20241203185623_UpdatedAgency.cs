using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class UpdatedAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Screens_ScreenId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "ScreenId",
                table: "MenuItems",
                newName: "AgencyId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_ScreenId",
                table: "MenuItems",
                newName: "IX_MenuItems_AgencyId");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 50, DateTimeKind.Utc).AddTicks(6747), new DateTime(2024, 12, 3, 18, 56, 23, 50, DateTimeKind.Utc).AddTicks(6751), "$2a$11$SWeXWgPl5b1izq3nuji/IOxXpaavAMNNt/xQEs/UcjAJf1X1Ruy/G" });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(4685), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(4693), "$2a$11$m0pZ1Fqo5dcPUGPfXolg6eInMMfslNmmklOaz4SmAEdRB.yrz0Hc6" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "AdminId", "AgencyId", "Description", "EndDate", "IsExpired", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Upcoming holiday schedule for the office.", new DateTime(2024, 12, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 12, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Holiday Announcement" },
                    { 2, 2, 2, "Reminder for the upcoming staff meeting.", new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Staff Meeting" }
                });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5313), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5332), new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5315) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5337), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5339), new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5342), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5343), new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5346), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5348), new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5349), new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5351), new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5350) });

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastCheckedIn", "LastUpdated" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(603), new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(604), new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(603) });

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastCheckedIn", "LastUpdated" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(605), new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(606), new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(606) });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Agencies_AgencyId",
                table: "MenuItems",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Agencies_AgencyId",
                table: "MenuItems");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "AgencyId",
                table: "MenuItems",
                newName: "ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_AgencyId",
                table: "MenuItems",
                newName: "IX_MenuItems_ScreenId");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 32, 992, DateTimeKind.Utc).AddTicks(8492), new DateTime(2024, 12, 2, 19, 32, 32, 992, DateTimeKind.Utc).AddTicks(8497), "$2a$11$F78/2W7PaWVypyknBNeSf.9D4.MiVhtVrGmTd9TiprjRvN27gNaeS" });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8338), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8342), "$2a$11$sa.JVOBCWNH9YjTwDkx5DOV5i8JFEL2LMi8nggScGhyxfA.Ttgc2." });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8740), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8754), new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8756), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8757), new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8759), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8760), new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8761), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8762), new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastUpdated", "TimeOutDate" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8763), new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8764), new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8763) });

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastCheckedIn", "LastUpdated" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6875), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6876), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastCheckedIn", "LastUpdated" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6884), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6885) });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Screens_ScreenId",
                table: "MenuItems",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
