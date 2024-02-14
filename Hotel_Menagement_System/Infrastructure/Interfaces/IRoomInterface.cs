
using Domain.Entities.HotelEntiries;

namespace Infrastructure.Interfaces;

public interface IRoomInterface:IRepository<Room>
{
    Task<List<Room>> GetAllWithTypeAndStatus();
    Task<Room> GetByIdWithTypeAndStatus(int id);




}
