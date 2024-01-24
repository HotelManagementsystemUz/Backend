

using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class PositionRepository : Repository<Position>, IPositionInterface
{
    public PositionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
