using AutoMapper;
using businessLogic;
using businessLogic.Model;
using GrpcBackEnd.Services;

using ProductGrpcServices.Protos;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = ConfigurAtuoMaper();
builder.Services.AddSingleton(mapper);// Add services to the container.
builder.Services.BusineAdd();
builder.Services.AddGrpc(option =>
{
    option.EnableDetailedErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductGrpc>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

static IMapper ConfigurAtuoMaper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<ProductsUI, ProductModel>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    return mapper;
}