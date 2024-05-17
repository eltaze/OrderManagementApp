


using BackEnd.UOF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BackEnd
{
    public static class ServicesExtensionCollection
    {
        public static void BackEndServ(this IServiceCollection services)
        {
           services.AddDbContext<OrderContext>(option =>
                        option.UseInMemoryDatabase("OrdersDB"));
            services.AddScoped<IUOF, UOFLibo>();
        }
    }
}
