using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class UpdateDepartmentAgencyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Agencies_AgencyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "DepartmentEmployee");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 6, 9, 12, 19, 17, DateTimeKind.Utc).AddTicks(8420), new DateTime(2024, 12, 6, 9, 12, 19, 17, DateTimeKind.Utc).AddTicks(8420), "$2a$11$WSKUFkGu56x42YdsCV4yRu3QbOUdtpbdGKjWlVM8rz4/hruBK0C/C" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeeId",
                table: "Departments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Agencies_AgencyId",
                table: "Departments",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_EmployeeId",
                table: "Departments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Agencies_AgencyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_EmployeeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_EmployeeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentEmployee",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployee", x => new { x.DepartmentsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 6, 6, 34, 14, 165, DateTimeKind.Utc).AddTicks(3480), new DateTime(2024, 12, 6, 6, 34, 14, 165, DateTimeKind.Utc).AddTicks(3480), "$2a$11$zDCegAyXINKMbIeOr2c6kORI6zG8V22/Fz4aSWAEWUphdzdpdMQB2" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployee_EmployeesId",
                table: "DepartmentEmployee",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Agencies_AgencyId",
                table: "Departments",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
