using Microsoft.Extensions.DependencyInjection;
using BackEnd;
using businessLogic.BL;

namespace businessLogic
{
    public static class ServicesExtensionCollection
    {
        public static void BusineAdd(this IServiceCollection Services) 
        {
            Services.BackEndServ();
            Services.AddTransient<IOrderBL, OrderBL>();
            Services.AddTransient<IProductBL, ProductBL>();
            Services.AddTransient<IOrderDetailsBL, OrderDetailsBL>();
            IMapper mapper = ConfigurAtuoMaper();
            Services.AddSingleton(mapper);
            Services.AddMemoryCache();
        }
        static IMapper ConfigurAtuoMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderUI>().ReverseMap();
                cfg.CreateMap<OrderDetails, OrderDetailsUI>().ReverseMap();
                cfg.CreateMap<Products, ProductsUI>().ReverseMap();

            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
