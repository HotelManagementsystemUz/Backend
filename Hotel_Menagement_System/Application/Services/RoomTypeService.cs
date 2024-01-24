

using Application.DTOs.HotelDtos.RoomType;

namespace Application.Services;

public class RoomTypeService(IUnitOfWork unitOfWork , IMapper mapper):IRoomTypeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddRoomType(AddRoomTypeDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "AddRoomTypeDto is null");
        }

        var roomType = _mapper.Map<RoomType>(dto);

        if (roomType == null)
        {
            throw new CustomException("Mapped RoomType is null");
        }

        if (roomType.IsValid())
        {
            throw new CustomException("RoomType is invalid");
        }

        if (roomType.PersonCount <= 0)
        {
            throw new CustomException("The number of persons in the room cannot be less than 0");
        }

        var roomTypes = await _unitOfWork.RoomTypeInterface.GetAllAsync();

        if (roomType.IsExist(roomTypes))
        {
            throw new CustomException("RoomType already exists");
        }

        await _unitOfWork.RoomTypeInterface.AddAsync(roomType);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteRoomTypeAsync(int id)
    {
        if(id <= 0)
        {
            throw new ArgumentException("Id manfi bo'lmasligi kerak ");
        }
        var roomType = await _unitOfWork.RoomTypeInterface.GetByIdAsync(id);
        if (roomType is null)
        {
            throw new CustomException("RoomType does not found");
        }
        await _unitOfWork.RoomTypeInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<RoomTypeDto>> GetAllRoomTypesAsync()
    {
        var roomTypes = await _unitOfWork.RoomTypeInterface.GetAllAsync();
        if (roomTypes is null)
        {
            throw new CustomException("RoomTypes list is  empty");
        }
        return roomTypes.Select(r => _mapper.Map<RoomTypeDto>(r)).ToList();
    }

    public async Task<RoomTypeDto> GetByIdRoomTypesAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id manfiy bo'lmasligi kerak ");
        }
        var roomType = await _unitOfWork.RoomTypeInterface.GetByIdAsync(id);
        if(roomType is null)
        {
            throw new NotFoundException("Bunday id raqamli RoomType mavjud emas");
        }
        return _mapper.Map<RoomTypeDto>(roomType);
    }

    public async Task UpdateRoomType(UpdateRoomTypeDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "AddRoomTypeDto is null");
        }

        var roomType = _mapper.Map<RoomType>(dto);

        if (roomType == null)
        {
            throw new CustomException("Mapped RoomType is null");
        }

        if (roomType.IsValid())
        {
            throw new CustomException("RoomType is invalid");
        }

        if (roomType.PersonCount <= 0)
        {
            throw new CustomException("The number of persons in the room cannot be less than 0");
        }

        var roomTypes = await _unitOfWork.RoomTypeInterface.GetAllAsync();

        await _unitOfWork.RoomTypeInterface.UpdateAsync(roomType);
        await _unitOfWork.SaveChangeAsync();
    }
}
