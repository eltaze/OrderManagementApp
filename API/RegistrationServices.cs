using API.Hcon;
using AutoMapper;
using BackEnd;
using BackEnd.UOF;
using businessLogic;
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
namespace API
{
    public static class RegistrationServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<InvoiceContext>(options =>
            options.UseInMemoryDatabase("InvoiceDB"));

            builder.Services.AddScoped<IUOF, UOFLibo>();

=            builder.Services.BackEndServ(); // Ensure BackEndServ method is setting up DI properly

            // Register Business Logic Layer services
            builder.Services.BusineAdd(); // Ensure BusineAdd method in businessLogic project is doing proper registration

            // Enable CORS and configure authentication
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200", "http://localhost:4200");
                                  });
            });

            // Register AutoMapper
            IMapper mapper = ConfigurAtuoMaper();
            builder.Services.AddSingleton(mapper);

            // Register BL services explicitly
            builder.Services.AddTransient<IInvoiceBL, InvoiceBL>();
            builder.Services.AddTransient<IProductBL, ProductBL>();
            builder.Services.AddTransient<IInvoiceDetailsBL, InvoiceDetailsBL>();
            builder.Services.AddTransient<IUserBL, UsersBL>();

            // Configure unit of work
            builder.Services.AddScoped<IUOF, UOFLibo>(); // Ensure UOFLibo is scoped to match DbContext

            // Configure in-memory cache
            builder.Services.AddMemoryCache();

            // Configure response compression for API
            builder.Services.AddResponseCompression();

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
    }
}