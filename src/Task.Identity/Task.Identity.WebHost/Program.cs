using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.Identity.Core.Abstractions;
using Tasks.Identity.Infrastructure;
using Tasks.Identity.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<IdentityContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
        .AddAspNetIdentity<IdentityUser>()
        .AddInMemoryApiResources(IdentityConfiguration.GetApiResources())
        .AddInMemoryClients(IdentityConfiguration.GetClients())
        .AddInMemoryIdentityResources(IdentityConfiguration.GetIdentityResources())
        .AddInMemoryApiScopes(IdentityConfiguration.GetScopes())
        .AddDeveloperSigningCredential();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddCors();

var app = builder.Build();

Initialize(app);

app.UseCors(builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });

app.UseAuthentication();

app.UseAuthorization();

app.UseIdentityServer();

app.Run();

void Initialize(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<IDbInitializer>();
        service.Initialize();
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}

