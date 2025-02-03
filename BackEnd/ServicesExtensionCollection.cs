


using DataBack.Data;
using BackEnd.UOF;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd
{
    public static class ServicesExtensionCollection
    {
        public static void BackEndServ(this IServiceCollection services)
        {
            services.AddScoped<InvoiceContext>(); 
            services.AddScoped<IUOF, UOFLibo>();
            services.AddScoped<ProductRepo>();
            services.AddScoped<InvoiceRepo>();
            services.AddScoped<InvoiceDetailsRepo>();
            services.AddScoped<UserRepo>();
        }
    }
}
