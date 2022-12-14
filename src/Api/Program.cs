using Api.Extensions;
using Domain.Extensions;

using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using Repositories;
using Repositories.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(GetAppConfiguration(args))
    .CreateLogger();

try
{
    Log.Information("Iniciando a aplicacao");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
    Log.Information("Serilog configurado");

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    Log.Information("Configurados servicos padrao");

    builder.Services.AddMappingProfiles();
    builder.Services.AddDomainServicesAndValidators();
    builder.Services.AddMongoDBRepositories(builder.Configuration);
    Log.Information("Configurados servicos da aplicacao");

    builder.Services.AddHealthChecks()
                    .AddCheck("self", () => HealthCheckResult.Healthy())
                    .AddMongoDb(builder.Configuration.GetConnectionString(DBConstants.ConnectionStringName), 
                                name: "database",
                                tags: new [] {"db", "deps"});
    Log.Information("Configurados HealthChecks");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();

    if (app.Configuration.GetSection("ActivateHttps").Get<bool>())
    {
        app.UseHttpsRedirection();
        Log.Information("Sem https redirection");
    }

    app.UseAuthorization();
    app.MapControllers();
    Log.Information("Aplicacao configurada");

    app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
        });
    Log.Information("Configurados endpoinst de HealthChecks");

    Log.Information("Inciando aplicacao");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

static IConfiguration GetAppConfiguration(string[] args)
{
    string enviroment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";
    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

    PreparerConfigBuilder(configurationBuilder, enviroment, args);

    return configurationBuilder.Build();
}

static void PreparerConfigBuilder(IConfigurationBuilder configurationBuilder, string enviroment, string[] args)
{
    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
        .AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: false);

    if (enviroment == "Development")
        configurationBuilder.AddUserSecrets<Program>(optional: true);

    configurationBuilder.AddEnvironmentVariables()
        .AddCommandLine(args);
}
