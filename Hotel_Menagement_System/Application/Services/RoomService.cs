using Application.DTOs.HotelDtos.Room;
using Application.DTOs.HotelDtos.RoomStatus;
using Application.DTOs.HotelDtos.RoomType;

namespace Application.Services;

public class RoomService(IUnitOfWork unitOfWork, IMapper mapper) : IRoomService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddRoomAsync(AddRoomDto room)
    {
        if (room is null)
        {
            throw new ArgumentNullException("Room is required");
        }
        var newRoom = _mapper.Map<Room>(room);
        if (newRoom is null)
        {
            throw new CustomException("Mepped room is null");
        }
        var rooms = await _unitOfWork.RoomInterface.GetAllAsync();
        if (newRoom.IsValid())
        {
            throw new CustomException("Room is invalid");
        }
        if(newRoom.IsExist(rooms))
        {
            throw new CustomException("Room is already exist");
        }
        var roomStatus = await _unitOfWork.RoomStatusInterface.GetByIdAsync(room.RoomStatusId);
        if(roomStatus is null)
        {
            throw new CustomException("RoomStatus does not found");
        }
        var roomType = await _unitOfWork.RoomTypeInterface.GetByIdAsync(room.RoomTypeId); if(roomType is null)
        {
            throw new CustomException("RoomType does not found");
        }


        await _unitOfWork.RoomInterface.AddAsync(newRoom);
        await _unitOfWork.SaveChangeAsync();

    }

    public async Task DeleteRoomAsync(int roomId)
    {
        if(roomId < 0)
        {
            throw new ArgumentNullException("RoomId manfiy bo'lmaslig kerak");
        }
        var room = await _unitOfWork.RoomInterface.GetByIdAsync(roomId);
        if(room is null)
        {
            throw new CustomException("Room does not found");
        }
        await _unitOfWork.RoomInterface.DeleteAsync(roomId);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<RoomDto>> FilterRooms(string searchText)
    {
        var rooms = await _unitOfWork.RoomInterface.GetAllAsync();

        var roomTypes = await _unitOfWork.RoomTypeInterface.GetAllAsync();
        var roomStatus = await _unitOfWork.RoomStatusInterface.GetAllAsync();

        var filteredRooms = rooms.Where(r =>
            r.Number.ToString().Contains(searchText) ||
            roomTypes.Any(rt => rt.Id == r.RoomTypeId && rt.Name.Contains(searchText)) ||
            roomStatus.Any(rs => rs.Id == r.RoomStatusId).ToString().Contains(searchText) ||
            r.Description.Contains(searchText)||
            r.Price.ToString().Contains(searchText)
        ).ToList();

        if(filteredRooms.Count <= 0)
        {
            throw new NotFoundException("Room topilmadi ");
        }

        var result = filteredRooms.Select(r => _mapper.Map<RoomDto>(r)).ToList();
        return result;
    }


    public async Task<List<RoomDto>> GetAllRoomAsync()
    {
        var rooms = await _unitOfWork.RoomInterface.GetAllAsync();
        return rooms.Select(r => _mapper.Map<RoomDto>(r)).ToList();
    }

    public async Task<List<GetRoomDto>> GetAllWithTypeAndStatus()
    {
        var rooms = await _unitOfWork.RoomInterface.GetAllWithTypeAndStatus();
                                                    

        var result = rooms.Select(room => new GetRoomDto
        {
            Number = room.Number,
            Price = room.Price,
            Description = room.Description,
            RoomType = new RoomTypeDto
            {
                Id = room.RoomType.Id,
                Name = room.RoomType.Name,
                PersonCount = room.RoomType.PersonCount
                
            },
            RoomStatus = new RoomStatusDto
            {
                Id = room.RoomStatus.Id,
                Name = room.RoomStatus.Name
            },
            Id = room.Id


        }).ToList();
   

        return result;
    }
    public async Task<GetRoomDto> GetByIdWithTypeAndStatus(int id)
    {
        var room = await _unitOfWork.RoomInterface.GetByIdWithTypeAndStatus(id);

        if (room == null)
        {
            return null;
        }

        var roomDto = new GetRoomDto
        {
            Number = room.Number,
            Price = room.Price,
            Description = room.Description,
            RoomType = new RoomTypeDto
            {
                Id = room.RoomType.Id,
                Name = room.RoomType.Name,
                PersonCount = room.RoomType.PersonCount
            },
            RoomStatus = new RoomStatusDto
            {
                Id = room.RoomStatus.Id,
                Name = room.RoomStatus.Name
            }
        };
        roomDto.Id = room.Id;

        return roomDto;
    }


    public async Task<RoomDto> GetByIdRoomAsync(int roomId)
    {
        var room = await _unitOfWork.RoomInterface.GetByIdAsync(roomId);
        if(room is null)
        {
            throw new CustomException("Room does not found");
        }
        return _mapper.Map<RoomDto>(room);
    }



    public async Task UpdateRoomAsync(UpdateRoomDto room)
    {
        if (room is null)
        {
            throw new ArgumentNullException("Room data is required for update");
        }

        var existingRoom = await _unitOfWork.RoomInterface.GetByIdAsync(room.Id);

        if (existingRoom is null)
        {
            throw new CustomException($"Room with ID {room.Id} not found");
        }

        _mapper.Map(room, existingRoom);

        var rooms = await _unitOfWork.RoomInterface.GetAllAsync();

        if (existingRoom.IsValid())
        {
            throw new CustomException("Updated room is invalid");
        }

        if (existingRoom.IsExist(rooms))
        {
            throw new CustomException("Updated room already exists");
        }

        var roomStatus = await _unitOfWork.RoomStatusInterface.GetByIdAsync(room.RoomStatusId);

        if (roomStatus is null)
        {
            throw new CustomException("RoomStatus not found");
        }

        var roomType = await _unitOfWork.RoomTypeInterface.GetByIdAsync(room.RoomTypeId);

        if (roomType is null)
        {
            throw new CustomException("RoomType not found");
        }

        await _unitOfWork.RoomInterface.UpdateAsync(existingRoom);
        await _unitOfWork.SaveChangeAsync();
    }
}
