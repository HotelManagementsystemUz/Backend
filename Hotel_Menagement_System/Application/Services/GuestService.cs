

using Messager.EskizUz;

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

        //var room = await _unitOfWork.RoomInterface.GetByIdAsync(guest.RoomId);
        //if (room is null)
        //{
        //    throw new NotFoundException("Bunday hona mavjud emas");
        //}

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

    public async Task<List<GuestDto>> FilterGuests(string searchText)
    {
        var guests = await _unitOfWork.GuestInterface.GetAllAsync();

        if (string.IsNullOrEmpty(searchText))
        {
            return guests.Select(x => _mapper.Map<GuestDto>(x)).ToList();
        }

        searchText = searchText.ToLower();

        var filteredGuests = guests.Where(x =>
            x.FirstName.ToLower().Contains(searchText) ||
            x.LastName.ToLower().Contains(searchText) ||
            x.FatherName.ToLower().Contains(searchText) ||
            x.CITIZENSHIP.ToLower().Contains(searchText) ||
            x.Passport.ToLower().Contains(searchText) ||
            x.Address.ToLower().Contains(searchText) ||
            x.PhoneNumber.ToLower().Contains(searchText) ||
            x.BirthDate.ToString().ToLower().Contains(searchText.ToLower())
        ).ToList();
        if(filteredGuests.Count <= 0)
        {
            throw new NotFoundException("Bunday mehmon topilmadi");
        }

        return filteredGuests.Select(x => _mapper.Map<GuestDto>(x)).ToList();
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

    public async Task SendSMS(int guestId, string text)
    {
        var messager = new MessagerAgent("sizning-email@example.com", "sizning-maxfiy-kalitingiz");

        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(guestId);
        if (guest is null)
        {
            throw new NotFoundException("Guest is not found ");
        }
        string guestNumber = guest.PhoneNumber;
        if (guestNumber == null)
        {
            throw new CustomException("GuestNumber is not found ");
        }
        var result =  await messager.SendSMSAsync(guestNumber, text);
        if (!result)
        {
            throw new CustomException("SMS yuborishda hatolik yuz berdi!");
        }
    }


    public async Task<string> Summa(int guestId)
    {
        if (guestId < 0)
        {
            throw new CustomException("Mehmon id raqami 0 dan katta bo'lish kerak ");
        }
        var guest = await _unitOfWork.GuestInterface.GetByIdAsync(guestId);
        if (guest is null)
        {
            throw new NotFoundException("Bunday mehmon mavjud emas");
        }
        var time = (DateTime.UtcNow - guest.DateOfIssue).Days;
        var room = await _unitOfWork.RoomInterface.GetByIdAsync(guest.RoomId);
        var result = (room.Price * time).ToString();
        return result;
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
