using businessLogic.Model;
using Grpc.Net.Client;
using GrpcBL.Interfaces;
using ProductGrpcServices.Protos;


namespace GrpcBL.BL
{
    public class ProductServ : IProductServices
    {

        private readonly ProductServices.ProductServicesClient productGrpc;

        public ProductServ()
        {
            var chanel =
    GrpcChannel.ForAddress("https://localhost:7036",
        new GrpcChannelOptions { HttpHandler = new SocketsHttpHandler() });
            productGrpc = new ProductServices.ProductServicesClient(chanel);
        }
        
        public List<ProductsUI> GetProduct()
        {
            var result =  productGrpc.GetAllProduct(null);
            List<ProductsUI> respons = new();
            foreach (ProductModel model in result.Products)
            {
                ProductsUI po = new();
                po.Name = model.ProductName;
                //po.Price = decimal.Parse(mode;
                po.Description = model.Discription;
                po.Id = model.Id;
                respons.Add(po);
            }
            return respons;
        }
        public bool  Create(ProductsUI model)
        {
            CancellationToken cancellationToken = new CancellationToken();
            ProductModel mod = new();
            mod.ProductName = model.Name;
            mod.Id = model.Id;
            mod.Discription = model.Description;
            CreateProducts create = new();
            create.Product = mod;
            var result = productGrpc.CreateProduct(create);
            bool x = result.IsDelete;
            return x;
        }
    }
}
