
using businessLogic;
using GrpcBackEnd.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.BusineAdd();
builder.Services.Configure<IConfiguration>(ConfigureServices());
builder.Services.AddGrpc(option =>
{
    option.EnableDetailedErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapGrpcService<ProductGrpc>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

static IConfiguration ConfigureServices()
{
    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    return configuration;
}