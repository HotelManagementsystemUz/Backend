



namespace Application.Services;

public class OrderService(IMapper mapper,
                          IUnitOfWork unitOfWork) : IOrderService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddOrderAsync(AddOrderDto orderDto)
    {
        if (orderDto is null)
        {
            throw new ArgumentNullException(nameof(orderDto), "Order is null");
        }

        var order = _mapper.Map<Order>(orderDto);

        if (order is null)
        {
            throw new ArgumentNullException("Order map is null");
        }

        if (order.IsValid())
        {
            throw new CustomException("Order is invalid");
        }

        var orderStatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orderStatuses == null)
        {
            throw new CustomException("OrderStatuses is null");
        }

        if (order.IsExist(orderStatuses.Cast<Order>()))
        {
            throw new CustomException("Order is already exist");
        }

        order.Status = null;
        order.Guest = null;
        await _unitOfWork.OrderInterface.AddAsync(order);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        if (id <= 0)
        {
            throw new CustomException("Id should be greater than 0");
        }

        var order = await _unitOfWork.OrderInterface.GetByIdAsync(id);

        if (order is null)
        {
            throw new ArgumentNullException("Order not found");
        }

        await _unitOfWork.OrderInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.OrderInterface.GetAllAsync();

        if (orders is null || !orders.Any())
        {
            throw new ArgumentNullException("Orders not found");
        }

        return orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.OrderInterface.GetByIdAsync(id);

        if (order is null)
        {
            throw new ArgumentNullException("Order not found");
        }

        return _mapper.Map<OrderDto>(order);
    }

    public async Task UpdateOrderAsync(UpdateOrderDto orderDto)
    {
        if (orderDto is null)
        {
            throw new ArgumentNullException(nameof(orderDto), "Order is null");
        }

        var order = _mapper.Map<Order>(orderDto);

        if (order is null)
        {
            throw new ArgumentNullException("Order map is null");
        }
        if (order.IsValid())
        {
            throw new CustomException("Order is invalid");
        }

        var orders = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orders == null)
        {
            throw new CustomException("Orders is null");

        }
      
        order.Status = null;
        order.Guest = null;
        await _unitOfWork.OrderInterface.UpdateAsync(order);
        await _unitOfWork.SaveChangeAsync();
    }
}
