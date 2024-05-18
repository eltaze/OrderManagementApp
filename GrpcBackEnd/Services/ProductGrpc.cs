using AutoMapper;
using businessLogic.Interface;
using businessLogic.Model;
using Grpc.Core;
using ProductGrpcServices.Protos;
namespace GrpcBackEnd.Services;

public class ProductGrpc: ProductServices.ProductServicesBase
{
    
    private readonly ILogger<GreeterService> _logger;
    private readonly IProductBL productBL;
    private readonly IMapper mapper;

    public ProductGrpc(ILogger<GreeterService> logger , IProductBL productBL,IMapper mapper)
    {
        _logger = logger;
        this.productBL = productBL;
        this.mapper = mapper;
    }
    public override async Task<ProductModels> GetByName(ProductName request, ServerCallContext context)
    {
        var id = request.Name;
        var result =  productBL.GetByName(id);
       
        var products = new ProductModels();
        foreach (var item in result)
        {
            products.Products.Add(mapper.Map<ProductModel>(item));
        }
        return products;
    }
    
    public override async Task<ProductModel> GetProductbyId(ProductsLookupModel request, ServerCallContext context)
    {
        var id = request.ProductId;
        var result = await productBL.GetById(id);
        var respons = mapper.Map<ProductModel>(result);
        return respons;
    }
    public override async Task<ProductModels> GetAllProduct(emty request, ServerCallContext context)
    {
        var GetProducts = await productBL.All();
        ProductModels products = new();
        foreach (var item in GetProducts)
        {
            ProductModel bl = new ProductModel { 
                Name = item.Name ,
                Description=item.Description,
                Id =item.Id, Price= (double)(item.Price) };
            products.Products.Add(bl);
        }
        return products;
    }
    public override async Task<productIsDelete> Updateproduct(UpdateProduct request, ServerCallContext context)
    {
        //var result = mapper.Map<ProductsUI>(request.Product);
        ProductsUI product = new ProductsUI
        {
            Price = request.Product.Price,
            Id = request.Product.Id,
            Name = request.Product.Name,
            Description = request.Product.Description
        };
        var ISupdate = await productBL.Update(product);
        var respon = new productIsDelete { IsDelete = ISupdate };
        return respon;
    }
    public override async Task<productIsDelete> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
    {
        var result = request.ProductId;
        var ISupdate = await productBL.Delete(result);
        var respon = new productIsDelete { IsDelete = ISupdate };
        return respon;
    }
    public override async Task<productIsDelete> CreateProduct(CreateProducts request, ServerCallContext context)
    {
        ProductsUI product = new ProductsUI
        {
            Price = request.Product.Price,
            Id = request.Product.Id,
            Name = request.Product.Name,
            Description = request.Product.Description
        };
       // product =this.mapper.Map<ProductsUI>(request.Product);
        var ISupdate = await productBL.Add(product);
        var respon = new productIsDelete { IsDelete = ISupdate };
        return respon;
    }
}
