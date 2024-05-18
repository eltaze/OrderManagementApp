using businessLogic.Model;
using Grpc.Net.Client;
using GrpcBL.Interfaces;
using ProductGrpcServices.Protos;


namespace GrpcBL.BL;

public class ProductServ : IProductServices
{

    private readonly ProductServices.ProductServicesClient productGrpc;

    public ProductServ()
    {
        
        var channel = GrpcChannel.ForAddress("https://localhost:5001");
          //  ,new GrpcChannelOptions { HttpHandler = handler });
        productGrpc = new ProductServices.ProductServicesClient(channel);
    }
    
    public List<ProductsUI> GetProduct()
    {
        emty emty = new emty();
        
        var result = productGrpc.GetAllProduct(emty);
        List<ProductsUI> respons = new();
        foreach (ProductModel model in result.Products)
        {
            ProductsUI po = new();
            po.Name = model.Name;
            po.Price = model.Price;
            po.Description = model.Description;
            po.Id = model.Id;
            respons.Add(po);
        }
        return respons;
    }
    public bool  Create(ProductsUI model)
    {
        //CancellationToken cancellationToken = new CancellationToken();
        ProductModel mod = new();
        mod.Name = model.Name;
        mod.Id = model.Id;
        mod.Description = model.Description;
        mod.Price = (double)(model.Price);
        CreateProducts create = new();
        create.Product = mod;
        var result = productGrpc.CreateProduct(create);
        bool x = result.IsDelete;
        return x;
    }
    public bool update(ProductsUI model)
    {
        //CancellationToken cancellationToken = new CancellationToken();
        ProductModel mod = new();
        mod.Name = model.Name;
        mod.Id = model.Id;
        mod.Description = model.Description;
        mod.Price = (double)(model.Price);
        UpdateProduct update = new();
        update.Product = mod;
        var result = productGrpc.Updateproduct(update);
        bool x = result.IsDelete;
        return x;
    }
    public bool Detele (int id)
    {
        DeleteProductRequest request = new DeleteProductRequest();
        request.ProductId = id;
        var result = productGrpc.DeleteProduct(request);
        return result.IsDelete;
    }
    public List<ProductsUI> GetProductByName(string name)
    {
        ProductName nam=new ProductName();
        nam.Name = name;

        var result = productGrpc.GetByName(nam);
        List<ProductsUI> respons = new();
        foreach (ProductModel model in result.Products)
        {
            ProductsUI po = new();
            po.Name = model.Name;
            po.Price = model.Price;
            po.Description = model.Description;
            po.Id = model.Id;
            respons.Add(po);
        }
        return respons;
    }
    public ProductsUI GetProductById(int id) 
    {
        ProductsLookupModel model = new ProductsLookupModel();
        model.ProductId = id;
        var rest = productGrpc.GetProductbyId(model);
        ProductsUI respons = new ProductsUI 
        {
            Id = rest.Id,
            Name = rest.Name,
            Price = rest.Price,
            Description = rest.Description
        };
        return respons;
    }
}
