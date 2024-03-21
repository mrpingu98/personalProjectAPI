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
// Add logging configuration
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductHandler, ProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
//    {
//        options.UseSqlite(
//        builder.Configuration["ConnectionStrings:LocalDbContextConnection"]);
//    });
//}
//else
//{
//    builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
//    {
//        options.UseMySQL(
//            builder.Configuration["ConnectionStrings:ProductionDbContextConnection"]
//            //"Database=p3rsonalprojectapi-database;Server=p3rsonalprojectapi-server.mysql.database.azure.com;User Id=gumxlrzbqq;Password=S08VBJW17FHMR55B$"
//            );
//    });
//}

var connectionString = builder.Configuration.GetConnectionString("ProductionDbContextConnection");
builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//builder.Services.AddDbContext<PersonalProjectDbContext>(options => {
//    options.UseMySQL(
//        //builder.Configuration["ConnectionStrings:ProductionDbContextConnection"]
//        "Database=p3rsonalprojectapi-database;Server=p3rsonalprojectapi-server.mysql.database.azure.com;User Id=gumxlrzbqq;Password=S08VBJW17FHMR55B$"
//        );
//});

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbInitialiser.Seed(app);

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var loggers = loggerFactory.CreateLogger<Program>();


// Log a message at application startup
loggers.LogInformation("Application started.");

app.Run();

