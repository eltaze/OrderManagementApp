namespace businessLogic.BL;

public class InvoiceDetailsBL(IMapper mapper, IUOF uOF) : IInvoiceDetailsBL
{
  private readonly IMapper mapper = mapper;
  private readonly IUOF uOF = uOF;
  public List<InvoiceDetailsUI> GetByOrderId(int id)
  {
    List<InvoicDetails> result = uOF.InvoiceDetails.GetByOrderId(id);
    if (result == null) { return null; }
    return mapper.Map<List<InvoiceDetailsUI>>(result);
  }
  public List<InvoiceDetailsUI> GetByProdcutId(int id)
  {
    List<InvoicDetails> result = uOF.InvoiceDetails.GetByProdcutId(id);
    if (result == null) { return null; }
    return mapper.Map<List<InvoiceDetailsUI>>(result);
  }
  public async Task<bool> Add(InvoiceDetailsUI entity)
  {
    var details = mapper.Map<InvoicDetails>(entity);

    var result = await uOF.InvoiceDetails.Add(details);
    await uOF.ComplateTask();
    return result;
  }
  public async Task<bool> Delete(object id)
  {
    var result = await uOF.InvoiceDetails.Delete(id);
    await uOF.ComplateTask();
    return result;
  }
  public async Task<bool> Update(InvoiceDetailsUI entity)
  {
    var details = mapper.Map<InvoicDetails>(entity);
    var result = await uOF.InvoiceDetails.Update(details);
    await uOF.ComplateTask();
    return result;
  }
  public async Task<InvoiceDetailsUI> GetById(int id)
  {
    var result = await uOF.InvoiceDetails.GetById(id);
    if (result == null) { return null; }
    return mapper.Map<InvoiceDetailsUI>(result);
  }
  public async Task<List<InvoiceDetailsUI>> All()
  {
    var result = await uOF.InvoiceDetails.All();
    if (result == null) { return null; }
    return mapper.Map<List<InvoiceDetailsUI>>(result);
  }
  public List<InvoiceDetailsUI> GetPaged<T>(int pageNumber, int invoiceid)
  {
    var result = uOF.InvoiceDetails.GetPage(pageNumber, invoiceid);
    if(result.Count == 0) { result = null; }
    return mapper.Map<List<InvoiceDetailsUI>>(result);
  }

}
