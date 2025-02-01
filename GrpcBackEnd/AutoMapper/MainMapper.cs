using AutoMapper;
using businessLogic.Model;


namespace GrpcBackEnd.AutoMapper
{
    public class MainMapper : Profile
    {
        public MainMapper()
        {
            CreateMap<ProductsUI, ProductModel>().ReverseMap();
        }
    }

}

