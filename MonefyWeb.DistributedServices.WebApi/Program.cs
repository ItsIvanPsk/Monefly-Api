using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonefyWeb.ApplicationService.Application.Contracts;
using MonefyWeb.ApplicationService.Application.Implementations;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Domain.Implementations;
using MonefyWeb.Infraestructure.Repository;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Infraestructure.Repository.Implementations;
using MonefyWeb.Transversal.Mappers;
using MonefyWeb.Transversal.Utils;
using MonefyWeb.Transversal.Utils.Health_Check;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inyection
// Configurations
// ------------------------------------------------------------------------------------------------
IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
builder.Services.AddSingleton<ConnectionConfiguration>();
builder.Services.AddScoped<IConnectionConfiguration, ConnectionConfiguration>();

// Contracts
// ------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAccountDomain, AccountDomain>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


// Entity Framework
// ------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("SQLDatabase"));
});

// Mapper Configurator
// ------------------------------------------------------------------------------------------------
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// ILog (Log4Net) Configurator
// ------------------------------------------------------------------------------------------------
builder.Services.AddSingleton<MonefyWeb.Transversal.Utils.ILogger, Logger>();

// ------------------------------------------------------------------------------------------------

// Api Versioning
// ------------------------------------------------------------------------------------------------
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});


// Health Check
// ------------------------------------------------------------------------------------------------
builder.Services
    .AddHealthChecks()
    .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck));


var app = builder.Build();

// Swagger Configuration
// ------------------------------------------------------------------------------------------------
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v2.0");
});

// Health Check Mapping
// ------------------------------------------------------------------------------------------------
app.MapHealthChecks("/health", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
