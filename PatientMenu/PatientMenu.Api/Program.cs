using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMenu.Api.Data;
using PatientMenu.Api.Infrastructure;
using PatientMenu.Api.Interface;
using PatientMenu.Api.Models;
using PatientMenu.Api.Repositories;
using PatientMenu.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<TenantIdHeaderOperationFilter>();
});

builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DatabaseBootstrap>();
builder.Services.AddSingleton<IDbConnectionFactory, SqliteConnectionFactory>();

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MenuDbContext>();
    context.Database.Migrate();

    if (!context.MenuItems.Any())
    {
        context.MenuItems.AddRange(
            new MenuItem { Name = "Oatmeal", Category = "Breakfast", IsGlutenFree = true, IsSugarFree = true, IsHeartHealthy = true, TenantId = "1" },
            new MenuItem { Name = "Pancakes", Category = "Breakfast", IsGlutenFree = false, IsSugarFree = false, IsHeartHealthy = false, TenantId = "1" },
            new MenuItem { Name = "Salad", Category = "Lunch", IsGlutenFree = true, IsSugarFree = true, IsHeartHealthy = true, TenantId = "1" },
            new MenuItem { Name = "Cake", Category = "Dessert", IsGlutenFree = false, IsSugarFree = false, IsHeartHealthy = false, TenantId = "1" }
        );
        context.SaveChanges();
    }
}

var bootstrap = app.Services.GetRequiredService<DatabaseBootstrap>();
bootstrap.Setup();

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
