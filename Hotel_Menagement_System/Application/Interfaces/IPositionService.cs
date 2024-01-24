

using Application.DTOs.HotelDtos.Position;

namespace Application.Interfaces;

public interface IPositionService
{
    Task<List<Position>> GetAllPositionsAsync();
    Task<Position> GetPositionByIdAsync(int positionId);
    Task AddPosition(AddPositionDto dto);
    Task DeletePositionByIdAsync(int positionId);
    Task UpdatePosition(UpdatePositionDto dto);
}
