
namespace GrpcBackEnd.Services;

public class OrderGrpc : OrdersServices.OrdersServicesBase
{
    private readonly IOrderBL orderBL;
    private readonly IMapper mapper;

    public OrderGrpc(IOrderBL orderBL, IMapper mapper)
    {
        this.orderBL = orderBL;
        this.mapper = mapper;
    }
    public override async Task<OrderIsDone> Ctreate(OrderModel request, ServerCallContext context)
    {
        OrderUI uI = new OrderUI
        {
            CustomerAddress = request.CustomerAddress,
            CustomerEmail = request.CustomerEmail,
            CustomerName = request.CustomerName,
            DueDate = request.DueDate.ToDateTime(),
            orderDate = request.OrderDate.ToDateTime()
        };
        var result = await orderBL.Add(uI);
        OrderIsDone xx = new OrderIsDone { Rest = result };
        return xx;
    }
    public override async Task<OrderIsDone> Delete(orderLookUp request, ServerCallContext context)
    {
        var req = request.Id;
        var result = await orderBL.Delete(req);
        return new OrderIsDone { Rest = result };
    }
    public override async Task<OrderModels> GetByCustomerName(GetByCustomer request, ServerCallContext context)
    {
        var nam = request.Name;
        var result = orderBL.GetByCustomerName(nam);
        OrderModels cont = new();
        foreach (var item in result)
        {
            OrderModel model = new OrderModel
            {
                Id = item.Id,
                CustomerName = item.CustomerName,
                CustomerAddress = item.CustomerAddress,
                CustomerEmail = item.CustomerEmail,
                DueDate = item.DueDate.ToTimestamp(),
                OrderDate = item.orderDate.ToTimestamp()
            };
            cont.OrderModel.Add(model);
        }
        return cont;
    }
    public override async Task<OrderModels> GetByOrderDate(GetByDate request, ServerCallContext context)
    {
        var Sdate = request.StartDate.ToDateTime();
        var Edate = request.EndDate.ToDateTime();
        var result = orderBL.orderdate(Sdate, Edate);
        OrderModels cont = new();
        foreach (var item in result)
        {
            OrderModel model = new OrderModel
            {
                Id = item.Id,
                CustomerName = item.CustomerName,
                CustomerAddress = item.CustomerAddress,
                CustomerEmail = item.CustomerEmail,
                DueDate = item.DueDate.ToTimestamp(),
                OrderDate = item.orderDate.ToTimestamp()
            };
            cont.OrderModel.Add(model);
        }
        return cont;
    }
    public override async Task<OrderModel> GetByOrderId(orderLookUp request, ServerCallContext context)
    {
        var id = request.Id;
        var result = await orderBL.GetById(id);
        OrderModel model = new OrderModel
        {
            Id = result.Id,
            CustomerName = result.CustomerName,
            CustomerAddress = result.CustomerAddress,
            CustomerEmail = result.CustomerEmail,
            DueDate = result.DueDate.ToTimestamp(),
            OrderDate = result.orderDate.ToTimestamp()
        };
        return model;
    }
    public override async Task<OrderModels> GettAll(Emty request, ServerCallContext context)
    {
        var result = await orderBL.All();
        OrderModels cont = new();
        foreach (var item in result)
        {
            OrderModel model = new OrderModel
            {
                Id = item.Id,
                CustomerName = item.CustomerName,
                CustomerAddress = item.CustomerAddress,
                CustomerEmail = item.CustomerEmail,
                DueDate = item.DueDate.ToTimestamp(),
                OrderDate = item.orderDate.ToTimestamp()
            };
            cont.OrderModel.Add(model);
        }
        return cont;
    }
    public override async Task<OrderIsDone> Update(OrderModel request, ServerCallContext context)
    {
        OrderUI uI = new OrderUI
        {
            CustomerAddress = request.CustomerAddress,
            CustomerEmail = request.CustomerEmail,
            CustomerName = request.CustomerName,
            DueDate = request.DueDate.ToDateTime(),
            orderDate = request.OrderDate.ToDateTime()
        };
        var result = await orderBL.Update(uI);
        OrderIsDone xx = new OrderIsDone { Rest = result };
        return xx;
    }
}