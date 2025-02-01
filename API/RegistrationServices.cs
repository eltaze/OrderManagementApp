using API.Hcon;
using AutoMapper;
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
        builder.Services.Configure<IConfiguration>(ConfigureServices());
        //Mapper Configration
        IMapper mapper = ConfigurAtuoMaper();
        builder.Services.AddSingleton(mapper);
        //Adding SignalR
       // builder.Services.AddSignalR();
        //Configuring EF
        builder.Services.AddDbContext<InvoiceContext>(option =>
        option.UseInMemoryDatabase("OrdersDB"));
        //configure Di For BL
        builder.Services.AddTransient<IInvoiceBL,InvoiceBL>();
        builder.Services.AddTransient<IProductBL,ProductBL>();
        builder.Services.AddTransient<IInvoiceDetailsBL,InvoiceDetailsBL>();
        builder.Services.AddTransient<IUserBL, UsersBL>();

        //Configure unit of work
        builder.Services.AddScoped<IUOF, UOFLibo>();
        //configure Auto Send Message to Client 
     //   builder.Services.AddHostedService<BackGroundServices>();
        //In-Memory Cach
        builder.Services.AddMemoryCache();
        builder.Services.AddResponseCompression(otn =>
        {
            otn.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });

        });
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "JwtBearer";
            option.DefaultChallengeScheme = "JwtBearer";
        }).AddJwtBearer("JwtBearer", JwtBearerOptions =>
        {
            JwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey =true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecretsoDon'tTellAnyOnePlease")),
                ValidateIssuer =false,
                ValidateAudience =false,
                ValidateLifetime =true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });
        //configuring Core for Angular and SingalR
        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy(name: "myAllowSpecificOrigins",
        //                      policy =>
        //                      {
        //                          policy.WithOrigins("http://localhost:4200",
        //                                              "http://localhost:4200");
        //                      });
        //});

    }
    private static IMapper ConfigurAtuoMaper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Invoices, InvoiceUI>().ReverseMap();
            cfg.CreateMap<InvoicDetails,InvoiceDetailsUI>().ReverseMap();
            cfg.CreateMap<Products,ProductsUI>().ReverseMap();
        });
        var mapper = config.CreateMapper();
        return mapper;
    }
    private static IConfiguration ConfigureServices()
    {
        // IConfiguration configuration; //= new Configuration();// = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        return configuration;
    }
}
