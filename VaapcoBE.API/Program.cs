using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using VaapcoBE.API.Auth;
using VaapcoBE.BL.Implementation;
using VaapcoBE.BL.Interface;
using VaapcoBE.DL;
using VaapcoBE.DL.Entities;
using VaapcoBE.DL.Repo.RepoImplementaion;
using VaapcoBE.DL.Repo.RepoInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
AutoMapper(builder.Services);
RegisterDbServices(builder.Services, builder.Configuration);
RegisterBusinessServices(builder.Services);
RegisterConfigurations(builder.Services, builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
AddSwagger(builder.Services);
AddJwtAuthentication(builder.Services, builder.Configuration);

static void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(config =>
    {
        config.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "1.0.0",
            Title = "Vaapco",
            Description = "VAAPCO Taste The Original",
            TermsOfService = new Uri("https://github.com/"),
            License = new OpenApiLicense
            {
                Name = "MIT"
            },
            Contact = new OpenApiContact
            {
                Email = "vaapco.ac@gmail.com",
                Name = "Netlio",
                Url = new Uri("https://vaapco.co.in/")
            }
        });

        config.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT",
            In = ParameterLocation.Header
        });

        var scheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };
        var req = new OpenApiSecurityRequirement();
        req.Add(scheme, new List<string>());
        config.AddSecurityRequirement(req);

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var path = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        config.IncludeXmlComments(path);
    });
}

static void RegisterBusinessServices(IServiceCollection services)
{
    services.AddScoped<IHeadlines, Headline>();
    services.AddScoped<IEventsBL, EventsBL>();
    services.AddScoped<IHeadlineRepo, HeadlineRepo>();
    services.AddScoped<IEventsRepo,EventsRepo>();
    services.AddScoped<IUserManagementService, UserManagementService>();
    // Register Identity
    services.AddIdentity<VaapcoUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>().
        AddDefaultTokenProviders();
}
static void AutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(Program));
}

static void RegisterDbServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
    });
}
static void RegisterConfigurations(IServiceCollection services, IConfiguration Configuration)
{
    services.Configure<JwtConfig>(Configuration.GetSection("Jwt"));
}

static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

    })
  .AddJwtBearer(options =>
  {
      var secret = configuration.GetSection("Jwt").GetValue<string>("Secret");
      options.TokenValidationParameters = new TokenValidationParameters
      {
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
          ValidateAudience = false,
          ValidateIssuer = false,
      };
      options.RequireHttpsMetadata = false;
  });
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "Vaapco");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(options =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
