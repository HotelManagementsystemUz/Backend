using Application.DTOs.HotelDtos.RoomStatus;
using Domain.Entities.HotelEntiries;

namespace Application.Services;

public class RoomStatusService(IUnitOfWork unitOfWork, 
                                IMapper mapper) : IRoomStatusService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddRoomStatusAsync(AddRoomStatusDto dto)
    {
        if(dto == null)
        {
              throw new ArgumentNullException("RoomStatus is null here");
        };
        var roomStatus =  _mapper.Map<RoomStatus>(dto);
        if (roomStatus is null)
        {
            throw new ArgumentNullException("RoomStatus map is null here");
        }
        var roomStatuses = await _unitOfWork.RoomStatusInterface.GetAllAsync();
        if (roomStatuses is null)
        {
            throw new ArgumentNullException("RoomStatuses are null here");
        }
        if (roomStatus.IsValid())
        {
            throw new CustomException("RoomStatus is invalid here");
        }
        if(roomStatus.IsExist(roomStatuses))
        {
            throw new CustomException("RoomStatus is already exist");
        }
        await _unitOfWork.RoomStatusInterface.AddAsync(roomStatus);
        await _unitOfWork.SaveChangeAsync();

    }

    public async Task DeleteRoomStatusAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id is null or invalid");
        }

        var roomStatus = await _unitOfWork.RoomStatusInterface.GetByIdAsync(id);

        if (roomStatus == null)
        {
            throw new CustomException($"RoomStatus with Id {id} not found");
        }

        await _unitOfWork.RoomStatusInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }


    public async Task<List<RoomStatusDto>> GetAllRoomStatusAsync()
    {
        var RoomStatuses = await _unitOfWork.RoomStatusInterface.GetAllAsync();
        if (RoomStatuses is null)
        {
            throw new NotFoundException("RoomStatuses does not found");
        }
        return RoomStatuses.Select(r => _mapper.Map<RoomStatusDto>(r)).ToList();
    }

    public async Task<RoomStatusDto> GetByIdRoomStatusAsync(int id)
    {
        var RoomStatus = await _unitOfWork.RoomStatusInterface.GetByIdAsync(id);
        if (RoomStatus is null)
        {
            throw new NotFoundException("RoomStatus does not found");
        }
        return _mapper.Map<RoomStatusDto>(RoomStatus);

    }

    public async Task UpdateRoomStatusAsync(UpdateRoomStatusDto dto)
    {

        if (dto == null)
        {
            throw new ArgumentNullException("RoomStatus is null here");
        };
        var roomStatus = _mapper.Map<RoomStatus>(dto);
        if (roomStatus is null)
        {
            throw new ArgumentNullException("RoomStatus map is null here");
        }
        var roomStatuses = await _unitOfWork.RoomStatusInterface.GetAllAsync();
        if (roomStatuses is null)
        {
            throw new ArgumentNullException("RoomStatuses are null here");
        }
        if (roomStatus.IsValid())
        {
            throw new CustomException("RoomStatus is invalid here");
        }
    
        await _unitOfWork.RoomStatusInterface.UpdateAsync(roomStatus);
        await _unitOfWork.SaveChangeAsync();
    }
}
