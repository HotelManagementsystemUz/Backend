using Application.DTOs.HotelDtos.RoomType;

namespace Application.Interfaces;

public interface IRoomTypeService
{

    Task<List<RoomTypeDto>> GetAllRoomTypesAsync();
    Task<RoomTypeDto> GetByIdRoomTypesAsync(int id);
    Task AddRoomType(AddRoomTypeDto dto);
    Task UpdateRoomType(UpdateRoomTypeDto dto);
    Task DeleteRoomTypeAsync(int id);
}
