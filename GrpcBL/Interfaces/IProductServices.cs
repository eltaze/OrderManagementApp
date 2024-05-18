

using businessLogic.Model;

namespace GrpcBL.Interfaces;

public interface IProductServices
{
    List<ProductsUI> GetProduct();
    bool Create(ProductsUI model);
    ProductsUI GetProductById(int id);
    List<ProductsUI> GetProductByName(string name);
    bool Detele(int id);
    bool update(ProductsUI model);
}
