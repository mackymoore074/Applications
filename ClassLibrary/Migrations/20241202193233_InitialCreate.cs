using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AllowedIpAddresses",
                columns: table => new
                {
                    IpAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedIpAddresses", x => x.IpAddress);
                    table.ForeignKey(
                        name: "FK_AllowedIpAddresses_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScreenType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastCheckedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    StatusMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MACAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screens_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screens_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Screens_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ScreenId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admins_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admins_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admins_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NewsItemBody = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    MoreInformationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItems_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "NewsItemAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsItemId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItemAgencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItemAgencies_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsItemAgencies_NewsItems_NewsItemId",
                        column: x => x.NewsItemId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsItemDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsItemId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItemDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItemDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsItemDepartments_NewsItems_NewsItemId",
                        column: x => x.NewsItemId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsItemLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsItemId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItemLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItemLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsItemLocations_NewsItems_NewsItemId",
                        column: x => x.NewsItemId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsItemScreens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsItemId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItemScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItemScreens_NewsItems_NewsItemId",
                        column: x => x.NewsItemId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsItemScreens_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AgencyId", "DateCreated", "DepartmentId", "Email", "FirstName", "LastLogin", "LastName", "LocationId", "PasswordHash", "Role", "ScreenId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 2, 19, 32, 32, 992, DateTimeKind.Utc).AddTicks(8492), null, "johndoe@agency.com", "John", new DateTime(2024, 12, 2, 19, 32, 32, 992, DateTimeKind.Utc).AddTicks(8497), "Doe", null, "$2a$11$F78/2W7PaWVypyknBNeSf.9D4.MiVhtVrGmTd9TiprjRvN27gNaeS", 2, null },
                    { 2, null, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8338), null, "janesmith@agency.com", "Jane", new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8342), "Smith", null, "$2a$11$sa.JVOBCWNH9YjTwDkx5DOV5i8JFEL2LMi8nggScGhyxfA.Ttgc2.", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "DateCreated", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6122), "Description for Agency1", "Agency1" },
                    { 2, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6146), "Description for Agency2", "Agency2" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "AgencyId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, "123 Finance St", null, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6844), "Foothill (Finance)" },
                    { 2, "456 HR Ave", null, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6848), "Main Office (HR)" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "AgencyId", "DateCreated", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6737), "Finance Department", 1, "Finance" },
                    { 2, 2, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6761), "Human Resources Department", 2, "HR" }
                });

            migrationBuilder.InsertData(
                table: "NewsItems",
                columns: new[] { "Id", "AdminId", "DateCreated", "Importance", "LastUpdated", "MoreInformationUrl", "NewsItemBody", "TimeOutDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8740), 1, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8754), "http://example.com/maintenance", "System maintenance scheduled. Please be aware of the downtime during this period.", new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8740), "Important Update" },
                    { 2, 2, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8756), 2, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8757), "http://example.com/new-policy", "A new company policy is now in effect. Please familiarize yourself with the changes.", new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8757), "New Policy" },
                    { 3, 1, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8759), 2, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8760), "http://example.com/holiday-schedule", "The company will be closed for the holidays from December 24th to December 26th. Please plan accordingly.", new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8759), "Holiday Schedule" },
                    { 4, 2, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8761), 1, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8762), "http://example.com/system-upgrade", "A system upgrade will take place this weekend. Expect intermittent outages from 10 PM to 2 AM.", new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8761), "System Upgrade" },
                    { 5, 1, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8763), 2, new DateTime(2024, 12, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8764), "http://example.com/recognition", "We are proud to recognize the efforts of our employees. A ceremony will be held this Friday.", new DateTime(2025, 1, 2, 19, 32, 33, 142, DateTimeKind.Utc).AddTicks(8763), "Employee Recognition" }
                });

            migrationBuilder.InsertData(
                table: "NewsItemAgencies",
                columns: new[] { "Id", "AgencyId", "NewsItemId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "NewsItemDepartments",
                columns: new[] { "Id", "DepartmentId", "NewsItemId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "AgencyId", "DateCreated", "DepartmentId", "IsOnline", "LastCheckedIn", "LastUpdated", "LocationId", "MACAddress", "Name", "ScreenType", "StatusMessage" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6875), 1, true, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6876), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6876), 1, "00:1A:2B:3C:4D:5E", "DM001", "LED", "Active" },
                    { 2, 2, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6884), 2, true, new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 12, 2, 19, 32, 32, 812, DateTimeKind.Utc).AddTicks(6885), 2, "11:22:33:44:55:66", "LH002", "LCD", "Active" }
                });

            migrationBuilder.InsertData(
                table: "NewsItemScreens",
                columns: new[] { "Id", "NewsItemId", "ScreenId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AgencyId",
                table: "Admins",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_DepartmentId",
                table: "Admins",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_LocationId",
                table: "Admins",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ScreenId",
                table: "Admins",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowedIpAddresses_locationId",
                table: "AllowedIpAddresses",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployee_EmployeesId",
                table: "DepartmentEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AgencyId",
                table: "Departments",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LocationId",
                table: "Departments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdminId",
                table: "Employees",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AgencyId",
                table: "Locations",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_AdminId",
                table: "MenuItems",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ScreenId",
                table: "MenuItems",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemAgencies_AgencyId",
                table: "NewsItemAgencies",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemAgencies_NewsItemId",
                table: "NewsItemAgencies",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemDepartments_DepartmentId",
                table: "NewsItemDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemDepartments_NewsItemId",
                table: "NewsItemDepartments",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemLocations_LocationId",
                table: "NewsItemLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemLocations_NewsItemId",
                table: "NewsItemLocations",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_AdminId",
                table: "NewsItems",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemScreens_NewsItemId",
                table: "NewsItemScreens",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemScreens_ScreenId",
                table: "NewsItemScreens",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_AgencyId",
                table: "Screens",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_DepartmentId",
                table: "Screens",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_LocationId",
                table: "Screens",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedIpAddresses");

            migrationBuilder.DropTable(
                name: "DepartmentEmployee");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "NewsItemAgencies");

            migrationBuilder.DropTable(
                name: "NewsItemDepartments");

            migrationBuilder.DropTable(
                name: "NewsItemLocations");

            migrationBuilder.DropTable(
                name: "NewsItemScreens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "NewsItems");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
