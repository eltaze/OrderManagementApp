using API.Hcon;
using AutoMapper;
using BackEnd.Data;
using BackEnd.UOF;
using businessLogic.BL;
using businessLogic.Interface;
using businessLogic.Model;
using DataBack.Data;
using DataBack.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace API;
public static class RegistrationServices
{
  public static void ConfigureServices(this WebApplicationBuilder builder)
  {
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Register the singleton service for managing the in-memory database
    builder.Services.AddSingleton<InMemoryDatabaseService>();

    // Register the DbContext as scoped, using the singleton service to create instances
    builder.Services.AddSingleton<InvoiceContext>(provider =>
    {
      var databaseService = provider.GetRequiredService<InMemoryDatabaseService>();
      return databaseService.CreateContext();
    });

    // Mapper Configuration
    IMapper mapper = ConfigurAtuoMaper();
    builder.Services.AddSingleton(mapper);

    // Configure DI for BL
    builder.Services.AddTransient<IInvoiceBL, InvoiceBL>();
    builder.Services.AddTransient<IProductBL, ProductBL>();
    builder.Services.AddTransient<IInvoiceDetailsBL, InvoiceDetailsBL>();
    builder.Services.AddTransient<IUserBL, UsersBL>();

    // Configure unit of work
    builder.Services.AddScoped<IUOF, UOFLibo>();

    // In-Memory Cache
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(otn =>
    {
      otn.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
    });

    // JWT Authentication Configuration
    builder.Services.AddAuthentication(option =>
    {
      option.DefaultAuthenticateScheme = "JwtBearer";
      option.DefaultChallengeScheme = "JwtBearer";
    }).AddJwtBearer("JwtBearer", JwtBearerOptions =>
    {
      JwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecretsoDon'tTellAnyOnePlease")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(5)
      };
    });
  }
  private static IMapper ConfigurAtuoMaper()
  {
    var config = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<Invoices, InvoiceUI>().ReverseMap();
      cfg.CreateMap<InvoicDetails, InvoiceDetailsUI>().ReverseMap();
      cfg.CreateMap<Products, ProductsUI>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    return mapper;
  }

  private static IConfiguration ConfigureServices()
  {
    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    return configuration;
  }
}
