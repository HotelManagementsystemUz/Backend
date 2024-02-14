

using Application.DTOs.HotelDtos.Room;
using Application.DTOs.HotelDtos.Staff;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<List<RoomDto>> GetAllRoomAsync();
    Task<RoomDto> GetByIdRoomAsync(int roomId);
    Task AddRoomAsync(AddRoomDto room);
    Task DeleteRoomAsync(int roomId);
    Task UpdateRoomAsync(UpdateRoomDto room);
    Task<List<RoomDto>> FilterRooms(string searchText);
    Task<List<GetRoomDto>> GetAllWithTypeAndStatus();
    Task<GetRoomDto> GetByIdWithTypeAndStatus(int id);


}