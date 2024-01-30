using Application.Common.Mappings;
using Application.DTOs.HotelDtos.Staff;

namespace Application.Services;

public class StaffService(IUnitOfWork unitOfWork, 
                          IMapper mapper) : IStaffService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddAsync(AddStaffDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException("Staff is null ");
        }

        var staff = _mapper.Map<Staff>(dto);

        if (staff == null)
        {
            throw new CustomException("Mapped staff is null ");
        }

        var position = await _unitOfWork.PositionInterface.GetByIdAsync(staff.PositionId);

        if (position == null)
        {
            throw new CustomException("Invalid PositionId");
        }

        if (staff.IsValid())
        {
            throw new CustomException("Staff is invalid");
        }

        var staffs = await _unitOfWork.StaffInterface.GetAllAsync();

        if (staff.IsExist(staffs))
        {
            throw new CustomException("Staff is already exist");
        }

        await _unitOfWork.StaffInterface.AddAsync(staff);
        await _unitOfWork.SaveChangeAsync();
    }
    public async Task DeleteAsync(int id)
    {
        if(id < 0)
        {
            throw new ArgumentException("Id manfiy bo'lishi mumkin emas");
        }
        var staff = await _unitOfWork.StaffInterface.GetByIdAsync(id); 
        if (staff == null)
        {
            throw new CustomException("Staff does not found");
        }
        await _unitOfWork.StaffInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<StaffDto>> GetAllStaffAsync()
    {
        var staffs = await _unitOfWork.StaffInterface.GetAllAsync();
        if(staffs == null)
        {
            throw new NotFoundException("Staff does not found");
        }
        return staffs.Select(s => _mapper.Map<StaffDto>(s)).ToList();
    }

    public async Task<StaffDto> GetByIdStaff(int id)
    {
        if( id < 0)
        {
            throw new ArgumentException("Id 0 dan katta bo'lish kerak");
        }
        var staff = await _unitOfWork.StaffInterface.GetByIdAsync(id);
        if(staff == null)
        {
            throw new CustomException("Staff does not found");
        }
        return _mapper.Map<StaffDto>(staff);
    }

    public async Task UpdateAsync(UpdateStaffDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException("Staff is null ");
        }
        var staff = _mapper.Map<Staff>(dto);
        if (staff == null)
        {
            throw new CustomException("Mapped staff is null ");
        }
        var position = await _unitOfWork.PositionInterface.GetByIdAsync(staff.PositionId);
        if (position == null)
        {
            throw new NotFoundException("Position does tot found");
        }
        if (staff.IsValid())
        {
            throw new CustomException("Staff is invalid");
        }

        await _unitOfWork.StaffInterface.UpdateAsync(staff);
        await _unitOfWork.SaveChangeAsync();
    }
    public async Task<List<StaffDto>> FilterStaff(string searchText)
    {
        var staffList = await _unitOfWork.StaffInterface.GetAllAsync();
        var filteredStaffList = staffList.Where(s =>
            s.FirstName.Contains(searchText) ||
            s.LastName.Contains(searchText) ||
            s.Username.Contains(searchText) ||
            s.Email.Contains(searchText) ||
            s.PhoneNumber.Contains(searchText) ||
            s.BirthDate.ToString().Contains(searchText) || 
            s.Address.Contains(searchText) ||
            s.Description.Contains(searchText)
        ).ToList();

        if(filteredStaffList.Count <= 0)
        {
            throw new NotFoundException("Bunday hodim topilmadi");
        }

        var result = filteredStaffList.Select(s => _mapper.Map<StaffDto>(s)).ToList();
        return result;
    }

}
