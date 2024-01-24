using Application.DTOs.HotelDtos.RoomStatus;

namespace Application.Interfaces;

public interface IRoomStatusService
{
    Task<List<RoomStatusDto>> GetAllRoomStatusAsync();
    Task<RoomStatusDto> GetByIdRoomStatusAsync(int id);

    Task AddRoomStatusAsync(AddRoomStatusDto dto);
    Task DeleteRoomStatusAsync(int id);
    Task UpdateRoomStatusAsync(UpdateRoomStatusDto dto);
}
