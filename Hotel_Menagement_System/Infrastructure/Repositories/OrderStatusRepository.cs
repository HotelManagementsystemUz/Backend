

using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusInterface
{
    public OrderStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
