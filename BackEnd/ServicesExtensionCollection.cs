


using BackEnd.UOF;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd
{
    public static class ServicesExtensionCollection
    {
        public static void BackEndServ(this IServiceCollection services)
        {
            services.AddDbContext<InvoiceContext>(option =>
                         option.UseInMemoryDatabase("OrdersDB"));
            services.AddScoped<IUOF, UOFLibo>();
        }
    }
}
