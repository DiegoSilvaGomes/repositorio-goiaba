using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Users.API.Data;
using Users.API.Data.Repositories;
using Users.API.Models;
using Users.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var server = builder.Configuration["DBServer"] ?? "sqldata";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "Numsey#2022Passw00rd";
var database = builder.Configuration["Database"] ?? "usersdb";

var connectionString = $"Server={server};Initial Catalog={database};User ID={user};Password={password}";

builder.Services.AddDbContext<UserDbContext>(options => 
        options.UseSqlServer($"Server={server};Initial Catalog={database};User ID={user};Password={password}"
));

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers();
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

DataBaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
