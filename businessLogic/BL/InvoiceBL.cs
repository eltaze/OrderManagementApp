namespace businessLogic.BL;

public class InvoiceBL(IMapper mapper, IUOF uOF) : IInvoiceBL
{
    private readonly IUOF uOF = uOF;
    private readonly IMapper mapper;
    public List<InvoiceUI> GetByCustomerName(string CustomerName)
    {
        var result = uOF.Invoice.GetByCustomerName(CustomerName);
        if (result == null) { return null; }
        return mapper.Map<List<InvoiceUI>>(result.ToList());
    }
    public List<InvoiceUI> orderdate(DateTime StartDate, DateTime EndDate)
    {
        var result = uOF.Invoice.GetByDates(StartDate, EndDate);
        if (result == null) { return null; }
        return mapper.Map<List<InvoiceUI>>(result.ToList());
    }
    public async Task<bool> Add(InvoiceUI entity)
    {
        var ord = mapper.Map<Invoices>(entity);
        var result = await uOF.Invoice.Add(ord);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await uOF.Invoice.Delete(id);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Update(InvoiceUI entity)
    {
        var ord = mapper.Map<Invoices>(entity);
        var result = await uOF.Invoice.Update(ord);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<List<InvoiceUI>> All()
    {
        var result = await uOF.Invoice.All();
        if (result == null) { return null; }
        return mapper.Map<List<InvoiceUI>>(result.ToList());
    }
    public async Task<InvoiceUI> GetById(int id)
    {
        var result = await uOF.Invoice.GetById(id);
        if (result == null) { return null; }
        return mapper.Map<InvoiceUI>(result);
    }
}
