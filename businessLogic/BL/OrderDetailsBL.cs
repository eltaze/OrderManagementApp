namespace businessLogic.BL;

public class OrderDetailsBL(IMapper mapper, IUOF uOF) : IOrderDetailsBL
{
    private readonly IMapper mapper = mapper;
    private readonly IUOF uOF = uOF;
    public List<OrderDetailsUI> GetByOrderId(int id)
    {
        List<OrderDetails> result = uOF.OrderDetails.GetByOrderId(id);
        if (result == null) { return null; }
        return mapper.Map<List<OrderDetailsUI>>(result);
    }
    public List<OrderDetailsUI> GetByProdcutId(int id)
    {
        List<OrderDetails> result = uOF.OrderDetails.GetByProdcutId(id);
        if (result == null) { return null; }
        return mapper.Map<List<OrderDetailsUI>>(result);
    }
    public async Task<bool> Add(OrderDetailsUI entity)
    {
        var details = mapper.Map<OrderDetails>(entity);

        var result = await uOF.OrderDetails.Add(details);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Delete(object id)
    {
        var result = await uOF.OrderDetails.Delete(id);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<bool> Update(OrderDetailsUI entity)
    {
        var details = mapper.Map<OrderDetails>(entity);
        var result = await uOF.OrderDetails.Update(details);
        await uOF.ComplateTask();
        return result;
    }
    public async Task<OrderDetailsUI> GetById(int id)
    {
        var result = await uOF.OrderDetails.GetById(id);
        if (result == null) { return null; }
        return mapper.Map<OrderDetailsUI>(result);
    }
    public async Task<List<OrderDetailsUI>> All()
    {
        var result = await uOF.OrderDetails.All();
        if (result == null) { return null; }
        return mapper.Map<List<OrderDetailsUI>>(result);
    }
}
