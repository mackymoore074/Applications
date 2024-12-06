using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class UodatedCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 4, 16, 40, 0, 879, DateTimeKind.Utc).AddTicks(3209), new DateTime(2024, 12, 4, 16, 40, 0, 879, DateTimeKind.Utc).AddTicks(3214), "$2a$11$f8sDLVoV7p/XI9OXPjORe.FfVUWjX8RvHhv3xWPNnJeXB8aVVnp7u" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 4, 2, 56, 36, 889, DateTimeKind.Utc).AddTicks(3550), new DateTime(2024, 12, 4, 2, 56, 36, 889, DateTimeKind.Utc).AddTicks(3550), "$2a$11$2xAkDKxqNo8gfhxGZCN3s.4gV26T2t6FWq4n2CLJoE/r.MF6ASxrm" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "AdminId", "AgencyId", "Description", "EndDate", "IsExpired", "StartDate", "Title" },
                values: new object[] { 1, 1, 1, "Upcoming holiday schedule for the office.", new DateTime(2024, 12, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 12, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Holiday Announcement" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "AdminId", "AgencyId", "Description", "EndDate", "IsExpired", "StartDate", "Title" },
                values: new object[] { 2, 2, 2, "Reminder for the upcoming staff meeting.", new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Staff Meeting" });
        }
    }
}
