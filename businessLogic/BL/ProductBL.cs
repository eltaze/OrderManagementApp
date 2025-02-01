namespace businessLogic.BL;
public class ProductBL(IUOF uOF,
                       IMemoryCache cache,
                       IConfiguration Cofig,
                       IMapper mapper) : IProductBL
{
    private readonly IMapper mapper = mapper;
    private readonly IUOF uOF = uOF;
    private readonly IMemoryCache cache = cache;
    public List<ProductsUI> GetByName(string Id)
    {
        var result = uOF.product.getByName(Id);
        if (result == null) { return null; }
        return mapper.Map<List<ProductsUI>>(result);
    }
    public async Task<bool> Update(ProductsUI entity)
    {
        var prod = mapper.Map<Products>(entity);
        var result = await uOF.product.Update(prod);
        await uOF.ComplateTask();
        await updatecashe();
        return result;
    }
    public async Task<bool> Add(ProductsUI entity)
    {
        var prod = mapper.Map<Products>(entity);
        var result = await uOF.product.Add(prod);
        await uOF.ComplateTask();
        await updatecashe();
        return result;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await uOF.product.Delete(id);
        await uOF.ComplateTask();
        await updatecashe();
        return result;
    }
    public async Task<List<ProductsUI>> All()
    {
        int fromsec = int.Parse(Cofig.GetSection("CashTime").Value);
        var output = cache.Get<List<ProductsUI>>("Products");
        if (output == null || output.Count == 0)
        {
            var result = await uOF.product.All();
            if (result == null) { return null; }
            output = mapper.Map<List<ProductsUI>>(result.ToList());
            cache.Set<List<ProductsUI>>("Products", output, TimeSpan.FromMinutes(fromsec));
        }
        return output;
    }
    public async Task<ProductsUI> GetById(int id)
    {
        var result = await uOF.product.GetById(id);
        if (result == null) { return null; }
        return mapper.Map<ProductsUI>(result);
    }
    private async Task updatecashe()
    {
        cache.Remove("Products");
        await All();
    }
}
