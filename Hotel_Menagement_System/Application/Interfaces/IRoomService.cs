

using Application.DTOs.HotelDtos.Room;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<List<RoomDto>> GetAllRoomAsync();
    Task<RoomDto> GetByIdRoomAsync(int roomId);
    Task AddRoomAsync(AddRoomDto room);
    Task DeleteRoomAsync(int roomId);
    Task UpdateRoomAsync(UpdateRoomDto room);
}
