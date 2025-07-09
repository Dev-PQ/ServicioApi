using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServicioApi.JWT.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<JwtService>();

var jwtKey = builder.Configuration["Jwt:Key"] ?? "uL5N8EdXcvDgn4AW+HYNm9M4Lwx+RNqd";
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // e.g., "https://localhost:5001"
        ValidAudience = builder.Configuration["Jwt:Audience"], // e.g., "https://localhost:5001"
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)) // Secret key
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.UseAuthentication(); // Use authentication middleware

app.UseAuthorization(); // Use authorization middleware

app.MapControllers();

app.Run();
