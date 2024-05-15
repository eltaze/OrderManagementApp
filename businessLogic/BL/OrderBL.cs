namespace businessLogic.BL;

public class OrderBL(IMapper mapper, IUOF uOF) : IOrderBL
{
    private readonly IUOF uOF = uOF;
    private readonly IMapper mapper; 
    public List<OrderUI> GetByCustomerName(string CustomerName)
    {
        var result = uOF.Order.GetByCustomerName(CustomerName);
        if (result == null) { return null; }
        return mapper.Map<List<OrderUI>>(result.ToList());
    }
    public List<OrderUI> orderdate(DateTime StartDate, DateTime EndDate)
    {
        var result = uOF.Order.GetByDates(StartDate, EndDate);
        if (result == null) { return null; }
        return mapper.Map<List<OrderUI>>(result.ToList());
    }
    public async Task<bool> Add(OrderUI entity)
    {
        var ord = mapper.Map<Order>(entity);
        var result = await uOF.Order.Add(ord);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await uOF.Order.Delete(id);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Update(OrderUI entity)
    {
        var ord = mapper.Map<Order>(entity);
        var result = await uOF.Order.Update(ord);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<List<OrderUI>> All()
    {
        var result = await uOF.Order.All();
        if (result == null) { return null; }
        return mapper.Map<List<OrderUI>>(result.ToList());
    }
    public async Task<OrderUI> GetById(int id)
    {
        var result = await uOF.Order.GetById(id);
        if (result == null) { return null; }
        return mapper.Map<OrderUI>(result);
    }
}
