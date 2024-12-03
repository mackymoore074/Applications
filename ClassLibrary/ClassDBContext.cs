using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Models.NewsItem;

namespace ClassLibrary
{
    public class ClassDBContext : DbContext
    {
        public ClassDBContext(DbContextOptions<ClassDBContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<NewsItemAgency> NewsItemAgencies { get; set; }
        public DbSet<NewsItemScreen> NewsItemScreens { get; set; }
        public DbSet<NewsItemDepartment> NewsItemDepartments { get; set; }
        public DbSet<NewsItemLocation> NewsItemLocations { get; set; }
        public DbSet<AllowedIpAddress> AllowedIpAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Admin relationships
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Agency)
                .WithMany(b => b.Admins)
                .HasForeignKey(a => a.AgencyId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Department)
                .WithMany(b => b.Admins)
                .HasForeignKey(a => a.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Location)
                .WithMany(b => b.Admins)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Screen)
                .WithMany(b => b.Admins)
                .HasForeignKey(a => a.ScreenId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.MenuItems)
                .WithOne(m => m.Admin)
                .HasForeignKey(m => m.AdminId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.NewsItems)
                .WithOne(n => n.Admin)
                .HasForeignKey(n => n.AdminId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Employees)
                .WithOne(e => e.Admin)
                .HasForeignKey(e => e.AdminId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete


            // MenuItem relationships
            modelBuilder.Entity<MenuItems>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MenuItems>()
                .HasOne(m => m.Admin)
                 .WithMany(a => a.MenuItems)
                 .HasForeignKey(m => m.AdminId);

            modelBuilder.Entity<MenuItems>()
                .HasOne(m => m.Agency)
                .WithMany(a => a.MenuItems)
                .HasForeignKey(m => m.AgencyId);
            // Avoid cascading delete // Avoid cascading delete

            // NewsItem relationships
            modelBuilder.Entity<NewsItem>()
                .HasMany(n => n.NewsItemAgencies)
                .WithOne(na => na.NewsItem)
                .HasForeignKey(na => na.NewsItemId);

            modelBuilder.Entity<NewsItem>()
                .HasMany(n => n.NewsItemScreens)
                .WithOne(ns => ns.NewsItem)
                .HasForeignKey(ns => ns.NewsItemId);

            modelBuilder.Entity<NewsItem>()
                .HasMany(n => n.NewsItemDepartments)
                .WithOne(nd => nd.NewsItem)
                .HasForeignKey(nd => nd.NewsItemId);

            modelBuilder.Entity<NewsItem>()
                .HasMany(n => n.NewsItemLocations)
                .WithOne(nl => nl.NewsItem)
                .HasForeignKey(nl => nl.NewsItemId);

            modelBuilder.Entity<NewsItem>()
                .HasOne(n => n.Admin)
                .WithMany(a => a.NewsItems)
                .HasForeignKey(n => n.AdminId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            // Employee relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Admin)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AdminId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            // Existing Screen relationships
            modelBuilder.Entity<Screen>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Screens)
                .HasForeignKey(s => s.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Screen>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Screens)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // AllowedIpAddress configuration
            modelBuilder.Entity<AllowedIpAddress>()
                .HasKey(aip => aip.IpAddress);

            // Seeding data for Agency, Department, Location, Screen, Admin, and NewsItem
            modelBuilder.Entity<Agency>().HasData(
                new Agency { Id = 1, Name = "Agency1", Description = "Description for Agency1", DateCreated = DateTime.UtcNow },
                new Agency { Id = 2, Name = "Agency2", Description = "Description for Agency2", DateCreated = DateTime.UtcNow }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Finance", Description = "Finance Department", DateCreated = DateTime.UtcNow, AgencyId = 1, LocationId = 1 },
                new Department { Id = 2, Name = "HR", Description = "Human Resources Department", DateCreated = DateTime.UtcNow, AgencyId = 2, LocationId = 2 }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Foothill (Finance)", Address = "123 Finance St", DateCreated = DateTime.UtcNow },
                new Location { Id = 2, Name = "Main Office (HR)", Address = "456 HR Ave", DateCreated = DateTime.UtcNow }
            );

            modelBuilder.Entity<Screen>().HasData(
                new Screen { Id = 1, Name = "DM001", AgencyId = 1, MACAddress = "00:1A:2B:3C:4D:5E", LocationId = 1, DepartmentId = 1, DateCreated = DateTime.UtcNow, ScreenType = "LED", LastUpdated = DateTime.UtcNow, LastCheckedIn = DateTime.UtcNow, IsOnline = true, StatusMessage = "Active" },
                new Screen { Id = 2, Name = "LH002", AgencyId = 2, MACAddress = "11:22:33:44:55:66", LocationId = 2, DepartmentId = 2, DateCreated = DateTime.UtcNow, ScreenType = "LCD", LastUpdated = DateTime.UtcNow, LastCheckedIn = DateTime.UtcNow, IsOnline = true, StatusMessage = "Active" }
            );

            // Seed MenuItems data, ensuring valid AgencyId is provided
            modelBuilder.Entity<MenuItems>().HasData(
                new MenuItems
                {
                    Id = 1,
                    Title = "Holiday Announcement",
                    Description = "Upcoming holiday schedule for the office.",
                    StartDate = new DateTime(2024, 12, 04, 08, 00, 00),
                    EndDate = new DateTime(2024, 12, 20, 17, 00, 00),
                    IsExpired = false,
                    AdminId = 1,
                    AgencyId = 1 // Reference to the AgencyId (make sure the Id exists)
                },
                new MenuItems
                {
                    Id = 2,
                    Title = "Staff Meeting",
                    Description = "Reminder for the upcoming staff meeting.",
                    StartDate = new DateTime(2024, 12, 05, 09, 00, 00),
                    EndDate = new DateTime(2024, 12, 05, 10, 00, 00),
                    IsExpired = false,
                    AdminId = 2,
                    AgencyId = 2 // Another valid AgencyId
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("ade123"),
                    Email = "johndoe@agency.com",
                    DateCreated = DateTime.UtcNow,
                    LastLogin = DateTime.UtcNow,
                    Role = Role.Admin
                },
                new Admin
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("ade123"),
                    Email = "janesmith@agency.com",
                    DateCreated = DateTime.UtcNow,
                    LastLogin = DateTime.UtcNow,
                    Role = Role.SuperAdmin
                }
            );

            modelBuilder.Entity<NewsItem>().HasData(
                new NewsItem
                {
                    Id = 1,
                    AdminId = 1,
                    Title = "Important Update",
                    NewsItemBody = "System maintenance scheduled. Please be aware of the downtime during this period.",
                    DateCreated = DateTime.UtcNow,
                    Importance = ImportanceLevel.VeryImportant,
                    TimeOutDate = DateTime.UtcNow.AddMonths(1),
                    LastUpdated = DateTime.UtcNow,
                    MoreInformationUrl = "http://example.com/maintenance"
                },
                new NewsItem
                {
                    Id = 2,
                    AdminId = 2,
                    Title = "New Policy",
                    NewsItemBody = "A new company policy is now in effect. Please familiarize yourself with the changes.",
                    DateCreated = DateTime.UtcNow,
                    Importance = ImportanceLevel.SomewhatImportant,
                    TimeOutDate = DateTime.UtcNow.AddMonths(1),
                    LastUpdated = DateTime.UtcNow,
                    MoreInformationUrl = "http://example.com/new-policy"
                },
                new NewsItem
                {
                    Id = 3,
                    AdminId = 1,
                    Title = "Holiday Schedule",
                    NewsItemBody = "The company will be closed for the holidays from December 24th to December 26th. Please plan accordingly.",
                    DateCreated = DateTime.UtcNow,
                    Importance = ImportanceLevel.SomewhatImportant,
                    TimeOutDate = DateTime.UtcNow.AddMonths(1),
                    LastUpdated = DateTime.UtcNow,
                    MoreInformationUrl = "http://example.com/holiday-schedule"
                },
                new NewsItem
                {
                    Id = 4,
                    AdminId = 2,
                    Title = "System Upgrade",
                    NewsItemBody = "A system upgrade will take place this weekend. Expect intermittent outages from 10 PM to 2 AM.",
                    DateCreated = DateTime.UtcNow,
                    Importance = ImportanceLevel.VeryImportant,
                    TimeOutDate = DateTime.UtcNow.AddMonths(1),
                    LastUpdated = DateTime.UtcNow,
                    MoreInformationUrl = "http://example.com/system-upgrade"
                },
                new NewsItem
                {
                    Id = 5,
                    AdminId = 1,
                    Title = "Employee Recognition",
                    NewsItemBody = "We are proud to recognize the efforts of our employees. A ceremony will be held this Friday.",
                    DateCreated = DateTime.UtcNow,
                    Importance = ImportanceLevel.SomewhatImportant,
                    TimeOutDate = DateTime.UtcNow.AddMonths(1),
                    LastUpdated = DateTime.UtcNow,
                    MoreInformationUrl = "http://example.com/recognition"
                }
            );

            // Seeding join tables
            modelBuilder.Entity<NewsItemAgency>().HasData(
                new NewsItemAgency
                {
                    Id = 1,
                    NewsItemId = 1,
                    AgencyId = 1
                }
            );

            modelBuilder.Entity<NewsItemScreen>().HasData(
                new NewsItemScreen
                {
                    Id = 1,
                    NewsItemId = 1,
                    ScreenId = 1
                }
            );

            modelBuilder.Entity<NewsItemDepartment>().HasData(
                new NewsItemDepartment
                {
                    Id = 1,
                    NewsItemId = 1,
                    DepartmentId = 1
                }
            );
        }
    }
}
