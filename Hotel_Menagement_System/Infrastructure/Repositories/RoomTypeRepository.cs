using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class RoomTypeRepository : Repository<RoomType>, IRoomTypeInterface
{
    public RoomTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
