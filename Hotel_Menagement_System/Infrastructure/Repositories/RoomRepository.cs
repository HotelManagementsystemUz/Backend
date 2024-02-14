

using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository : Repository<Room>, IRoomInterface
{
    public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Room>> GetAllWithTypeAndStatus()
    {
        var list = await _dbContext.Rooms.Include(r => r.RoomStatus)
                                          .Include(r => r.RoomType)
                                          .ToListAsync();
        return list;
    }

    public async Task<Room> GetByIdWithTypeAndStatus(int id)
    {
        var room = await _dbContext.Rooms.Include(r => r.RoomStatus)
                                          .Include(r => r.RoomType)
                                          .FirstOrDefaultAsync(i => i.Id == id);

        return room;
    }
}
