using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ClassLibrary.Models;
using ClassLibrary;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container
builder.Services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Add DbContext for EF Core
builder.Services.AddDbContext<ClassDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClassDB"),
        sqlOptions => sqlOptions.MigrationsAssembly("ClassLibrary")) // Specify the migrations assembly
        .EnableSensitiveDataLogging()  // Enable logging of sensitive data (e.g., values in the queries)
        .LogTo(Console.WriteLine, LogLevel.Information); // Log to console at Information level
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();