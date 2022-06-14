using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot();

builder.Services.AddCors();

builder.Services.AddAuthentication()
    .AddJwtBearer("IdentityApiKey", config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
        };

        config.Authority = "http://identity-server:80";
        config.Audience = "m2m.client";

        config.RequireHttpsMetadata = false;
    });

var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .WithMethods("GET", "PUT", "DELETE", "POST", "PATCH");
});

await app.UseOcelot();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
