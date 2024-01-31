



using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class OrderService(IMapper mapper,
                          IUnitOfWork unitOfWork,
                          UserManager<ApplicationUser> userManager) : IOrderService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

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
        var user = await _userManager.FindByIdAsync(order.AdminId);
        if (user is null)
        {
            throw new NotFoundException("Admin does not found");
        }

        var orderStatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orderStatuses == null)
        {
            throw new CustomException("OrderStatuses is null");
        }
        var orders = await _unitOfWork.OrderInterface.GetAllAsync();
        if (order.IsExist(orders))
        {
            throw new CustomException("Order is already exist");
        }
        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(order.GuestId);
        if (guest is null)
        {
            throw new NotFoundException("Guest does not found");
        }
        var orderStatus = await _unitOfWork.OrderStatusInterface.GetByIdAsync(order.StatusId);
        if (orderStatus is null)
        {
            throw new NotFoundException("OrderStatus does not found");
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

    public async Task<List<OrderDto>> GetAllOrdersWithStatusAsync()
    {
        var orders = await _unitOfWork.OrderInterface.GetAllOrdersWithStatusAsync();

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
        var user = await _userManager.FindByIdAsync(order.AdminId);
        if (user is null)
        {
            throw new NotFoundException("Admin does not found");
        }

        var orderStatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orderStatuses == null)
        {
            throw new CustomException("OrderStatuses is null");
        }

  
        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(order.GuestId);
        if (guest is null)
        {
            throw new NotFoundException("Guest does not found");
        }
        var orderStatus = await _unitOfWork.OrderStatusInterface.GetByIdAsync(order.StatusId);
        if (orderStatus is null)
        {
            throw new NotFoundException("OrderStatus does not found");
        }
        order.Status = null;
        order.Guest = null;
        await _unitOfWork.OrderInterface.UpdateAsync(order);
        await _unitOfWork.SaveChangeAsync();
    }
}
