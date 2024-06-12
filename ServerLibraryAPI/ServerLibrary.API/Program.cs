using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.DTO.Models;
using ServerLibrary.Repo.Data;
using ServerLibrary.Repo.Interfaces;
using ServerLibrary.Repo.Repositories;
using ServerLibrary.Repo.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServerLibraryDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<JWTService>(); // able to inject JWTService Class into controllers

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ServerLibraryDbContext>();

//builder.Services.AddIdentity<User, IdentityRole>()
//        .AddEntityFrameworkStores<ServerLibraryDbContext>()
//        .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;

    options.SignIn.RequireConfirmedEmail = true;
})
    .AddRoles<IdentityRole>() // be able to make roles
    .AddRoleManager<RoleManager<IdentityRole>>() // be able to make use of RoleManager
    .AddSignInManager<SignInManager<User>>() // make use of sign in manager
    .AddUserManager<UserManager<User>>() // make use of UserManager to create users
    .AddEntityFrameworkStores<ServerLibraryDbContext>() // providing our database context
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validate the server that created that token
            ValidateAudience = false, // Dont validate the audience (angular side)
            ValidateIssuerSigningKey = true, // Validate the key (from appsettings.json) used to sign the token 
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // validate whoever is issuing the JWT
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) 
        };
    });


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

//app.MapIdentityApi<User>();

app.UseHttpsRedirection();

// Adding UseAuthentication into our pipeline and this should come before UseAuthorization
// Authentication verifies the identity of a user, and authorization determines their access rights
app.UseAuthentication();
app.UseAuthorization();


app.UseCors("AllowAll");

app.MapControllers();

app.Run();
