using Microsoft.EntityFrameworkCore;
using personalProjectAPI.Db;
using personalProjectAPI.Handlers;
using personalProjectAPI.Interfaces;
using personalProjectAPI.Repositories;
using personalProjectAPI.ApplicationDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductHandler, ProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
    {
        options.UseSqlServer("Server=localhost;Database=PersonalProjectDb;User Id=sa;Password=Jim-biscuits-Rat;TrustServerCertificate=True");
    });
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer("Server=localhost;Database=PersonalProjectDb;User Id=sa;Password=Jim-biscuits-Rat;TrustServerCertificate=True");
    });
}
else
{
    builder.Services.AddDbContext<PersonalProjectDbContext>(options =>
    {
        options.UseSqlServer("Server=tcp:personalproject123.database.windows.net,1433;Initial Catalog=personalproject;Persist Security Info=False;User ID=admin@123@personalproject123;Password=Password@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    });
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer("Server=tcp:personalproject123.database.windows.net,1433;Initial Catalog=personalproject;Persist Security Info=False;User ID=admin@123@personalproject123;Password=Password@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    });
}

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapIdentityApi<IdentityUser>();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger().RequireAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbInitialiser.Seed(app);

app.Run();

