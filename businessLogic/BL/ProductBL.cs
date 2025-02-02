namespace businessLogic.BL;
public class ProductBL(IUOF uOF,
                       IConfiguration Cofig,
                       IMapper mapper) : IProductBL
{
  private readonly IMapper mapper = mapper;
  private readonly IUOF uOF = uOF;
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
    return result;
  }
  public async Task<bool> Add(ProductsUI entity)
  {
    var prod = mapper.Map<Products>(entity);
    var result = await uOF.product.Add(prod);
    await uOF.ComplateTask();
    return result;
  }
  public async Task<bool> Delete(int id)
  {
    var result = await uOF.product.Delete(id);
    await uOF.ComplateTask();
    return result;
  }
  public async Task<List<ProductsUI>> All()
  {
    int fromsec = int.Parse(Cofig.GetSection("CashTime").Value);
    // var output = cache.Get<List<ProductsUI>>("Products");

    var result = await uOF.product.All();
    if (result == null) { return null; }
    var output = mapper.Map<List<ProductsUI>>(result.ToList());
    return output;
  }
  public async Task<ProductsUI> GetById(int id)
  {
    var result = await uOF.product.GetById(id);
    if (result == null) { return null; }
    return mapper.Map<ProductsUI>(result);
  }
  public async Task<List<ProductsUI>> GetByPage(int page, int PageSize)
  {
    var result = uOF.Invoice.GetPaged<Products>(page);
    if (result.Count == 0) { return null; }
    return mapper.Map<List<ProductsUI>>(result);
  }

}
