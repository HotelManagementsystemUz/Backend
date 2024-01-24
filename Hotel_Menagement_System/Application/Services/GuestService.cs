

namespace Application.Services;

public class GuestService : IGuestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GuestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task AddAsync(AddGuestDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto), "Guest is null here");
        }

        var guest = _mapper.Map<Guest>(dto);

        if (guest is null)
        {
            throw new ArgumentNullException("Guest map is null here");
        }

        if (guest.IsValidGuest())
        {
            throw new CustomException("Guest is invalid");
        }

        var guests = await _unitOfWork.GuestInterface.GetAllAsync();

        if (guest.IsExistGuest(guests))
        {
            throw new CustomException("Guest already exists");
        }

        await _unitOfWork.GuestInterface.AddAsync(guest);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new CustomException("Id should be greater than 0");
        }

        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(id);

        if (guest is null)
        {
            throw new ArgumentNullException("Guest not found");
        }

        await _unitOfWork.GuestInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<GuestDto>> GetAllAsync()
    {
        var guests = await _unitOfWork.GuestInterface.GetAllAsync();

        if (guests is null || !guests.Any())
        {
            throw new ArgumentNullException("Guests not found");
        }

        return guests.Select(g => _mapper.Map<GuestDto>(g)).ToList();
    }

    public async Task<GuestDto> GetByIdAsync(int id)
    {
        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(id);

        if (guest is null)
        {
            throw new ArgumentNullException("Guest not found");
        }

        return _mapper.Map<GuestDto>(guest);
    }

    public async Task UpdateAsync(UpdateGuestDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto), "Guest is null here");
        }

        var guest = _mapper.Map<Guest>(dto);

        if (guest is null)
        {
            throw new ArgumentNullException("Guest map is null here");
        }

        if (guest.IsValidGuest())
        {
            throw new CustomException("Guest is invalid");
        }



        await _unitOfWork.GuestInterface.UpdateAsync(guest);
        await _unitOfWork.SaveChangeAsync();
    }
}
