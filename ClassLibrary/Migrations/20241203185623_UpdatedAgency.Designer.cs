﻿// <auto-generated />
using System;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassLibrary.Migrations
{
    [DbContext(typeof(ClassDBContext))]
    [Migration("20241203185623_UpdatedAgency")]
    partial class UpdatedAgency
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassLibrary.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("ScreenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ScreenId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 50, DateTimeKind.Utc).AddTicks(6747),
                            Email = "johndoe@agency.com",
                            FirstName = "John",
                            LastLogin = new DateTime(2024, 12, 3, 18, 56, 23, 50, DateTimeKind.Utc).AddTicks(6751),
                            LastName = "Doe",
                            PasswordHash = "$2a$11$SWeXWgPl5b1izq3nuji/IOxXpaavAMNNt/xQEs/UcjAJf1X1Ruy/G",
                            Role = 2
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(4685),
                            Email = "janesmith@agency.com",
                            FirstName = "Jane",
                            LastLogin = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(4693),
                            LastName = "Smith",
                            PasswordHash = "$2a$11$m0pZ1Fqo5dcPUGPfXolg6eInMMfslNmmklOaz4SmAEdRB.yrz0Hc6",
                            Role = 1
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(390),
                            Description = "Description for Agency1",
                            Name = "Agency1"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(424),
                            Description = "Description for Agency2",
                            Name = "Agency2"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.AllowedIpAddress", b =>
                {
                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("locationId")
                        .HasColumnType("int");

                    b.HasKey("IpAddress");

                    b.HasIndex("locationId");

                    b.ToTable("AllowedIpAddresses");
                });

            modelBuilder.Entity("ClassLibrary.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("LocationId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(557),
                            Description = "Finance Department",
                            LocationId = 1,
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 2,
                            AgencyId = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(558),
                            Description = "Human Resources Department",
                            LocationId = 2,
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ClassLibrary.Models.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScreenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("ClassLibrary.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Finance St",
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(576),
                            Name = "Foothill (Finance)"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 HR Ave",
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(586),
                            Name = "Main Office (HR)"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AgencyId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            AgencyId = 1,
                            Description = "Upcoming holiday schedule for the office.",
                            EndDate = new DateTime(2024, 12, 20, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExpired = false,
                            StartDate = new DateTime(2024, 12, 4, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Holiday Announcement"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 2,
                            AgencyId = 2,
                            Description = "Reminder for the upcoming staff meeting.",
                            EndDate = new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExpired = false,
                            StartDate = new DateTime(2024, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Staff Meeting"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("MoreInformationUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsItemBody")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("NewsItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5313),
                            Importance = 1,
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5332),
                            MoreInformationUrl = "http://example.com/maintenance",
                            NewsItemBody = "System maintenance scheduled. Please be aware of the downtime during this period.",
                            TimeOutDate = new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5315),
                            Title = "Important Update"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5337),
                            Importance = 2,
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5339),
                            MoreInformationUrl = "http://example.com/new-policy",
                            NewsItemBody = "A new company policy is now in effect. Please familiarize yourself with the changes.",
                            TimeOutDate = new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5338),
                            Title = "New Policy"
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5342),
                            Importance = 2,
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5343),
                            MoreInformationUrl = "http://example.com/holiday-schedule",
                            NewsItemBody = "The company will be closed for the holidays from December 24th to December 26th. Please plan accordingly.",
                            TimeOutDate = new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5343),
                            Title = "Holiday Schedule"
                        },
                        new
                        {
                            Id = 4,
                            AdminId = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5346),
                            Importance = 1,
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5348),
                            MoreInformationUrl = "http://example.com/system-upgrade",
                            NewsItemBody = "A system upgrade will take place this weekend. Expect intermittent outages from 10 PM to 2 AM.",
                            TimeOutDate = new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5347),
                            Title = "System Upgrade"
                        },
                        new
                        {
                            Id = 5,
                            AdminId = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5349),
                            Importance = 2,
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5351),
                            MoreInformationUrl = "http://example.com/recognition",
                            NewsItemBody = "We are proud to recognize the efforts of our employees. A ceremony will be held this Friday.",
                            TimeOutDate = new DateTime(2025, 1, 3, 18, 56, 23, 211, DateTimeKind.Utc).AddTicks(5350),
                            Title = "Employee Recognition"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemAgency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<int>("NewsItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("NewsItemId");

                    b.ToTable("NewsItemAgencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            NewsItemId = 1
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("NewsItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NewsItemId");

                    b.ToTable("NewsItemDepartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            NewsItemId = 1
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NewsItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("NewsItemId");

                    b.ToTable("NewsItemLocations");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemScreen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NewsItemId")
                        .HasColumnType("int");

                    b.Property<int>("ScreenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewsItemId");

                    b.HasIndex("ScreenId");

                    b.ToTable("NewsItemScreens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NewsItemId = 1,
                            ScreenId = 1
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Screen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastCheckedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("MACAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ScreenType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Screens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(603),
                            DepartmentId = 1,
                            IsOnline = true,
                            LastCheckedIn = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(604),
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(603),
                            LocationId = 1,
                            MACAddress = "00:1A:2B:3C:4D:5E",
                            Name = "DM001",
                            ScreenType = "LED",
                            StatusMessage = "Active"
                        },
                        new
                        {
                            Id = 2,
                            AgencyId = 2,
                            DateCreated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(605),
                            DepartmentId = 2,
                            IsOnline = true,
                            LastCheckedIn = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(606),
                            LastUpdated = new DateTime(2024, 12, 3, 18, 56, 22, 895, DateTimeKind.Utc).AddTicks(606),
                            LocationId = 2,
                            MACAddress = "11:22:33:44:55:66",
                            Name = "LH002",
                            ScreenType = "LCD",
                            StatusMessage = "Active"
                        });
                });

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("DepartmentEmployee");
                });

            modelBuilder.Entity("ClassLibrary.Models.Admin", b =>
                {
                    b.HasOne("ClassLibrary.Models.Agency", "Agency")
                        .WithMany("Admins")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ClassLibrary.Models.Department", "Department")
                        .WithMany("Admins")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ClassLibrary.Models.Location", "Location")
                        .WithMany("Admins")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ClassLibrary.Models.Screen", "Screen")
                        .WithMany("Admins")
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Agency");

                    b.Navigation("Department");

                    b.Navigation("Location");

                    b.Navigation("Screen");
                });

            modelBuilder.Entity("ClassLibrary.Models.AllowedIpAddress", b =>
                {
                    b.HasOne("ClassLibrary.Models.Location", "Location")
                        .WithMany("AllowedIpAddresses")
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ClassLibrary.Models.Department", b =>
                {
                    b.HasOne("ClassLibrary.Models.Agency", "Agency")
                        .WithMany("Departments")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Location", "Locations")
                        .WithMany("Departments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("ClassLibrary.Models.Employee", b =>
                {
                    b.HasOne("ClassLibrary.Models.Admin", "Admin")
                        .WithMany("Employees")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("ClassLibrary.Models.Location", b =>
                {
                    b.HasOne("ClassLibrary.Models.Agency", null)
                        .WithMany("Locations")
                        .HasForeignKey("AgencyId");
                });

            modelBuilder.Entity("ClassLibrary.Models.MenuItems", b =>
                {
                    b.HasOne("ClassLibrary.Models.Admin", "Admin")
                        .WithMany("MenuItems")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Agency", "Agency")
                        .WithMany("MenuItems")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItem", b =>
                {
                    b.HasOne("ClassLibrary.Models.Admin", "Admin")
                        .WithMany("NewsItems")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemAgency", b =>
                {
                    b.HasOne("ClassLibrary.Models.Agency", "Agency")
                        .WithMany("NewsItemAgencies")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.NewsItem", "NewsItem")
                        .WithMany("NewsItemAgencies")
                        .HasForeignKey("NewsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("NewsItem");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemDepartment", b =>
                {
                    b.HasOne("ClassLibrary.Models.Department", "Department")
                        .WithMany("NewsItemDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.NewsItem", "NewsItem")
                        .WithMany("NewsItemDepartments")
                        .HasForeignKey("NewsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("NewsItem");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemLocation", b =>
                {
                    b.HasOne("ClassLibrary.Models.Location", "Location")
                        .WithMany("NewsItemLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.NewsItem", "NewsItem")
                        .WithMany("NewsItemLocations")
                        .HasForeignKey("NewsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("NewsItem");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItemScreen", b =>
                {
                    b.HasOne("ClassLibrary.Models.NewsItem", "NewsItem")
                        .WithMany("NewsItemScreens")
                        .HasForeignKey("NewsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Screen", "Screen")
                        .WithMany()
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewsItem");

                    b.Navigation("Screen");
                });

            modelBuilder.Entity("ClassLibrary.Models.Screen", b =>
                {
                    b.HasOne("ClassLibrary.Models.Agency", "Agency")
                        .WithMany("Screen")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Department", "Department")
                        .WithMany("Screens")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ClassLibrary.Models.Location", "Location")
                        .WithMany("Screens")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Agency");

                    b.Navigation("Department");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.HasOne("ClassLibrary.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassLibrary.Models.Admin", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("NewsItems");
                });

            modelBuilder.Entity("ClassLibrary.Models.Agency", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Departments");

                    b.Navigation("Locations");

                    b.Navigation("MenuItems");

                    b.Navigation("NewsItemAgencies");

                    b.Navigation("Screen");
                });

            modelBuilder.Entity("ClassLibrary.Models.Department", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("NewsItemDepartments");

                    b.Navigation("Screens");
                });

            modelBuilder.Entity("ClassLibrary.Models.Location", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("AllowedIpAddresses");

                    b.Navigation("Departments");

                    b.Navigation("NewsItemLocations");

                    b.Navigation("Screens");
                });

            modelBuilder.Entity("ClassLibrary.Models.NewsItem", b =>
                {
                    b.Navigation("NewsItemAgencies");

                    b.Navigation("NewsItemDepartments");

                    b.Navigation("NewsItemLocations");

                    b.Navigation("NewsItemScreens");
                });

            modelBuilder.Entity("ClassLibrary.Models.Screen", b =>
                {
                    b.Navigation("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}