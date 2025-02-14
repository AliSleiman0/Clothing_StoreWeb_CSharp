using ClothingStore.Domain.Config;
using ClothingStore.Domain.Models;
using ClothingStore.Infrastructure.Context;
using ClothingStore.Infrastructure.Repository;
using ClothingStore.Services.Helpers;
using ClothingStore.Services.Interfaces;
using ClothingStore.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Solvit.Services.Services.UserServices.Authentication;
using System.Text;
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

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemsService, CartItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemsService, OrderItemsService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserAuthService, UserAuthService>();
builder.Services.AddIdentity<User, IdentityRole<int>>() 
    .AddEntityFrameworkStores<ClothStoreDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));



builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
// Add cors policy
var corsPolicy = "cors-policy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();
DataSeeder.SeedData(app.Services);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(corsPolicy);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
