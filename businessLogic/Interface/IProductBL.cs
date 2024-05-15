namespace businessLogic.Interface
{
    public interface IProductBL
    {
        Task<bool> Add(ProductsUI entity);
        Task<List<ProductsUI>> All();
        Task<bool> Delete(int id);
        Task<ProductsUI> GetById(int id);
        List<ProductsUI> GetByName(string Id);
        Task<bool> Update(ProductsUI entity);
    }
}