

using businessLogic.Model;

namespace GrpcBL.Interfaces;

public interface IProductServices
{
    List<ProductsUI> GetProduct();
    bool Create(ProductsUI model);
}
