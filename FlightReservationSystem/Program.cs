using FlightReservationSystem.Models;
using FlightReservationSystem.Configs;
using FlightReservationSystem.Mappers;
using FlightReservationSystem.Middlewares;
using FlightReservationSystem.Repositories;
using FlightReservationSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------
// Serilog Logging
// ------------------------------------------
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

// ------------------------------------------
// Database Context
// ------------------------------------------
builder.Services.AddDbContext<FlightReservation>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// ------------------------------------------
// CORS Configuration
// -----------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// ------------------------------------------
// AutoMapper Configuration
// ------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Register mapping profiles

// ------------------------------------------
// Dependency Injection - Repositories
// ------------------------------------------
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IAirplaneRepository, AirplaneRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightPriceRepository, FlightPriceRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
// Register the Reviews Repository
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

// ------------------------------------------
// Dependency Injection - Services
// ------------------------------------------
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IBookingService, BookingService>();
// Register the Reviews Service
builder.Services.AddScoped<IReviewService, ReviewService>();

// ------------------------------------------
// JWT Authentication
// ------------------------------------------
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()
    ?? throw new InvalidOperationException("JwtSettings configuration is missing or invalid.");

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = key,
        ClockSkew = TimeSpan.Zero
    };
});

// ------------------------------------------
// Swagger Configuration with JWT
// ------------------------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Flight Reservation System API",
        Version = "v1",
        Description = "Manage flights, reservations, airplanes, users, reviews, and more."
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter: Bearer {your JWT token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            System.Array.Empty<string>()
        }
    });
});

// ------------------------------------------
// Build the App
// ------------------------------------------
var app = builder.Build();

// Use Global Exception Handler Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Reservation System API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();
