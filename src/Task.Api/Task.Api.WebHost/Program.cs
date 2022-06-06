using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Application.MapProfiles;
using Tasks.Api.Application.Services.Behaviors;
using Tasks.Api.Application.Services.TaskTypes.Queryes;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Infrastructure;
using Tasks.Api.Infrastructure.Data;
using Tasks.Api.Infrastructure.Repository;
using Tasks.Api.WebHost.Middlewares;
using Tasks.Shared.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSnakeCaseNamingConvention();
    options.UseLazyLoadingProxies();
});

builder.Services.AddCors();

builder.Services.AddMediatR(typeof(GetAllTaskTypesQuery).Assembly);

builder.Services.AddAutoMapper(typeof(TaskMapPfofile).Assembly);

builder.Services.AddMassTransit(x =>
{
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

        cfg.Message<IUserContract>(cfg => { });

        cfg.AutoDelete = true;

        cfg.ConfigureEndpoints(ctx);
    });
});

builder.Services.AddTransient<ExceptionHandlerMiddleware>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineWithValidationCommandBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(GetAllTaskTypesQuery).Assembly);


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

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapDefaultControllerRoute();

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
