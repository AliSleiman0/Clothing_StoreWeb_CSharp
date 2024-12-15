using ClothingStore.Infrastructure.Context;
using ClothingStore.Infrastructure.Repository;
using ClothingStore.Services.Helpers;
using ClothingStore.Services.Interfaces;
using ClothingStore.Services.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClothStoreDBContext>(options =>
{
    string defaultConnectionString = builder.Configuration.GetConnectionString("CLOTH_STORE_CONNECTION_STRING");
    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString));
});

builder.Services.AddScoped<IClothStoreRepository, ClothStoreRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
