using Application.DTOs.HotelDtos.OrderStatus;

namespace Application.Interfaces;

public interface IOrderStatusService
{
    Task<List<OrderStatusDto>> GetAllOrderStatusAsync();
    Task<OrderStatusDto> GetByIdOrderStatusAsync(int id);
    Task AddOrderStatusAsync(AddOrderStatusDto dto);
    Task DeleteOrderStatusAsync(int id);
    Task UpdateOrderStatusAsync(UpdateOrderStatusDto dto);
}
