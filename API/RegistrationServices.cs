using API.Hcon;
using AutoMapper;
using BackEnd.Model;
using BackEnd.Repository;
using BackEnd.UOF;
using businessLogic.BL;
using businessLogic.Model;
using DataBack.Data;
using DataBack.Model;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        builder.Services.AddSignalR();
        //Configuring EF
        builder.Services.AddDbContext<OrderContext>(option =>
        option.UseInMemoryDatabase("OrdersDB"));
        //configure Di For BL
        builder.Services.AddTransient<OrderBL>();
        builder.Services.AddTransient<ProductBL>();
        builder.Services.AddTransient<OrderDetailsBL>();
        //Configure unit of work
        builder.Services.AddScoped<IUOF,UOF>();
        //configure Auto Send Message to Client 
        builder.Services.AddHostedService<BackGroundServices>();
        //In-Memory Cach
        builder.Services.AddMemoryCache();
        builder.Services.AddResponseCompression(otn =>
        {
            otn.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });

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
            cfg.CreateMap<Order, OrderUI>().ReverseMap();
            cfg.CreateMap<OrderDetails,OrderDetailsUI>().ReverseMap();
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
