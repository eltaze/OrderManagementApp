using AutoMapper;
using businessLogic.Model;
using ProductGrpcServices.Protos;


namespace GrpcBackEnd.AutoMapper
{  
        public class MainMapper : Profile
        {
            public MainMapper()
            {
                CreateMap<ProductsUI,ProductModel>().ReverseMap();
            }
        }
    
}

