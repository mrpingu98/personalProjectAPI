using Microsoft.EntityFrameworkCore;
using MySql;
using Microsoft.Extensions.Options;
using personalProjectAPI.Db;
using personalProjectAPI.Handlers;
using personalProjectAPI.Interfaces;
using personalProjectAPI.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductHandler, ProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<PersonalProjectDbContext>(options => {
        options.UseSqlite(
        builder.Configuration["ConnectionStrings:LocalDbContextConnection"]);
    });
}
else
{
    builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
    options.UseMySQL(
        builder.Configuration["ConnectionStrings:LocalDbContextConnection"])
        );
} 


var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbInitialiser.Seed(app);

app.Run();

