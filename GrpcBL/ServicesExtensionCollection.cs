using Grpc.Net.Client;
using GrpcBL.BL;
using GrpcBL.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace GrpcBL;

public static class ServicesExtensionCollection 
{
    public static void AddGrpcBl(this IServiceCollection services) 
    {
        services.AddScoped<IProductServices, ProductServ>();
    }
}
