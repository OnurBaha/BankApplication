using BankingCreditSystem.Application;
using BankingCreditSystem.Persistence;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankingCreditSystem.Application.Features.IndividualCustomers.Profiles;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Core.Security;
using MediatR;
using BankingCreditSystem.Core.Application.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking Credit System API", Version = "v1" });
});

// Add Application Services
builder.Services.AddApplicationServices();

// Add Persistence Services
builder.Services.AddPersistenceServices(builder.Configuration);

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// Add MediatR
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateIndividualCustomerCommand).Assembly));

// JWT ve Authorization ayarları
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

// Add Business Rules
builder.Services.AddScoped<IndividualCustomerBusinessRules>();

// Add services
builder.Services.AddScoped<IHttpExceptionHandler, HttpExceptionHandler>();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Credit System API V1");
    });
}

// Add middleware (before routing/endpoints)
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
