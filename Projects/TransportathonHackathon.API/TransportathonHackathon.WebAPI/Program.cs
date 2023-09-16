using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.IoC;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TransportathonHackathon.Application;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Infrastructure.DriverLicenseVerifiers.FakeDriverLicenseVerifier;
using TransportathonHackathon.Infrastructure.Payment.FakePaymentService;
using TransportathonHackathon.Infrastructure.SignalR;
using TransportathonHackathon.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options => { });

// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddApplicationServices(Assembly.GetExecutingAssembly());

builder.Services.RegisterLogger(ServiceLifetime.Scoped, typeof(FileLogger), typeof(MsSqlLogger));

builder.Services.AddScoped<ITokenHelper<Guid>, JwtHelper<Guid>>();

builder.Services.AddScoped<IPaymentService, FakePaymentService>();
builder.Services.AddScoped<IDriverLicenseVerifierService, FakeDriverLicenseVerifierService>();

builder.Services.AddExceptionHandlers(ServiceLifetime.Scoped);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSignalR();

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    Core.Security.Jwt.TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Security.Jwt.TokenOptions>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/messages")))
                context.Token = accessToken;

            return Task.CompletedTask;
        }
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };

    options.AddSecurityRequirement(securityRequirement);
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebAPI", Version = "v1", Description = "Swagger page for your API" });
});

var app = builder.Build();

ServiceTool.SetSetviceProvider(app.Services);

// Configure the HTTP request pipeline.

app.UseCors(builder => builder.WithOrigins(app.Configuration.GetSection("AllowedHosts").Get<string[]>()).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.ConfigureCustomExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.MapHub<MessageHub>("/messages");
app.Run();