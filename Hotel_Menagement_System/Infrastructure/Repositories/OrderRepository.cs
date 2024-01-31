

using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderInterface
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetAllOrdersWithStatusAsync()
        => await _dbContext.Orders.Include(o => o.Status)
                                  .Include(g => g.Guest)
                                  .ToListAsync();
}
