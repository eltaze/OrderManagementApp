using Grpc.Net.Client;
using GrpcBL.BL;
using GrpcBL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ProductGrpcServices.Protos;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Threading.Channels;


namespace GrpcBL;

public static class ServicesExtensionCollection 
{
    public static void AddGrpcBl(this IServiceCollection services) 
    {
         var channel = GrpcChannel.ForAddress(
        "https://localhost:7036",
    new GrpcChannelOptions
            {
              HttpHandler = new HttpClientHandler()
             });

        //var client = new ProductServices.ProductServicesClient(channel);
        //services.AddGrpcClient<ProductServices.ProductServicesClient>(option =>
        //{
            
        //});
        
        services.AddScoped<IProductServices, ProductServ>();
    }
}
