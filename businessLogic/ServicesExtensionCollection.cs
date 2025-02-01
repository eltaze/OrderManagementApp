using BackEnd;
using BackEnd.Model;
using businessLogic.BL;
using Microsoft.Extensions.DependencyInjection;

namespace businessLogic
{
    public static class ServicesExtensionCollection
    {
        public static void BusineAdd(this IServiceCollection Services)
        {
            Services.BackEndServ();
            Services.AddTransient<IInvoiceBL, InvoiceBL>();
            Services.AddTransient<IProductBL, ProductBL>();
            Services.AddTransient<IInvoiceDetailsBL, InvoiceDetailsBL>();
            Services.AddTransient<IUserBL, UsersBL>();
            IMapper mapper = ConfigurAtuoMaper();
            Services.AddSingleton(mapper);
            Services.AddMemoryCache();
        }
        static IMapper ConfigurAtuoMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoices, InvoiceUI>().ReverseMap();
                cfg.CreateMap<InvoicDetails, InvoiceDetailsUI>().ReverseMap();
                cfg.CreateMap<Products, ProductsUI>().ReverseMap();
                cfg.CreateMap<Users, UsersUI>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
