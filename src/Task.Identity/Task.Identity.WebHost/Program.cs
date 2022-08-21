using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.Identity.Aplication.Consumers;
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

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateUserConsumer>();
    x.AddConsumer<UpdateUserConsumer>();

    x.UsingRabbitMq((ctx, cfg) =>
    {
        var massTransitSection = builder.Configuration.GetSection("MassTransit");
        var url = massTransitSection.GetValue<string>("Url");
        var host = massTransitSection.GetValue<string>("Host");
        var userName = massTransitSection.GetValue<string>("UserName");
        var password = massTransitSection.GetValue<string>("Password");

        cfg.Host($"rabbitmq://{url}/{host}", configurator =>
        {
            configurator.Username(userName);
            configurator.Password(password);
        });

        cfg.AutoDelete = true;

        cfg.ConfigureEndpoints(ctx);
    });
});


var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

