using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var signingKey = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(signingKey),
            RequireExpirationTime = true
        };
    });
builder.Services.AddAuthorization();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

var summaries = new List<string>
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Count)]
        ))
        .ToArray();
    return forecast;
});


app.MapGet("/summaries",  () => summaries).RequireAuthorization();
app.MapPost("/summaries", (Summary value) => summaries.Add(value.Name));
app.MapDelete("/summaries", [Authorize(Roles = "Admin")] (string value) => summaries.Remove(value));

app.MapGet("/login", async context =>
{
    if (context.Request.Headers.TryGetValue("username", out var username) &&
        context.Request.Headers.TryGetValue("password", out var password))
    {
        if (username != "admin" || password != "pass")
            return;

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Admin")
            };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor();

        tokenDescriptor.Subject = new ClaimsIdentity(claims);
        tokenDescriptor.Expires = DateTime.Now.AddSeconds(30);
        tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256);
        var token = tokenHandler.CreateToken(tokenDescriptor);

        await context.Response.WriteAsync(tokenHandler.WriteToken(token));
    }
});

app.Run();

class Summary
{
    public string Name { get; set; } = "";
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}