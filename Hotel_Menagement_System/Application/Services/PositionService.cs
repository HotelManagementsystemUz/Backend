

using Application.DTOs.HotelDtos.Position;

namespace Application.Services;

public class PositionService(IUnitOfWork unitOfWork, IMapper mapper) : IPositionService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddPosition(AddPositionDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Position is null here");
        };

        var position = _mapper.Map<Position>(dto);
        if (position is null)
        {
            throw new ArgumentNullException("Position map is null here");
        }

        var positions = await _unitOfWork.PositionInterface.GetAllAsync();
        if (positions is null)
        {
            throw new ArgumentNullException("Positions are null here");
        }

        if (position.IsValid())
        {
            throw new CustomException("Position is invalid ");
        }
        if (position.IsExist(positions))
        {
            throw new CustomException("Position is already exist");
        }

        await _unitOfWork.PositionInterface.AddAsync(position);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeletePositionByIdAsync(int positionId)
    {
        if (positionId <= 0)
        {
            throw new ArgumentException("PositionId is null or invalid");
        }

        var position = await _unitOfWork.PositionInterface.GetByIdAsync(positionId);

        if (position == null)
        {
            throw new CustomException($"Position with Id {positionId} not found");
        }

        await _unitOfWork.PositionInterface.DeleteAsync(positionId);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<Position>> GetAllPositionsAsync()
    {
        var positions = await _unitOfWork.PositionInterface.GetAllAsync();
        if (positions is null)
        {
            throw new NotFoundException("Positions not found");
        }
        return positions.ToList();
    }

    public async Task<Position> GetPositionByIdAsync(int positionId)
    {
        var position = await _unitOfWork.PositionInterface.GetByIdAsync(positionId);
        if (position == null)
        {
            throw new NotFoundException($"Position with Id {positionId} not found");
        }
        return position;
    }

    public async Task UpdatePosition(UpdatePositionDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Position is null here");
        };

        var position = _mapper.Map<Position>(dto);
        if (position is null)
        {
            throw new ArgumentNullException("Position map is null here");
        }

        var positions = await _unitOfWork.PositionInterface.GetAllAsync();
        if (positions is null)
        {
            throw new ArgumentNullException("Positions are null here");
        }

        if (position.IsValid())
        {
            throw new CustomException("Position is invalid ");
        }
        await _unitOfWork.PositionInterface.UpdateAsync(position);
        await _unitOfWork.SaveChangeAsync();
    }
}
