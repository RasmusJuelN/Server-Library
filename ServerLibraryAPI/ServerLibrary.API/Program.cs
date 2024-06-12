using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ServerLibrary.DTO.Models;
using ServerLibrary.Repo.Data;
using ServerLibrary.Repo.Interfaces;
using ServerLibrary.Repo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServerLibraryDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ServerLibraryDbContext>();

//builder.Services.AddIdentity<User, IdentityRole>()
//        .AddEntityFrameworkStores<ServerLibraryDbContext>()
//        .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
