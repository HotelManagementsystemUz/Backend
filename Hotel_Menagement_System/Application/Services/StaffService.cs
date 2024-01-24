using Application.DTOs.HotelDtos.Staff;

namespace Application.Services;

public class StaffService(IUnitOfWork unitOfWork, 
                          IMapper mapper) : IStaffService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public Task AddAsync(AddStaffDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<StaffDto>> GetAllStaffAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StaffDto> GetByIdStaff(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateStaffDto dto)
    {
        throw new NotImplementedException();
    }
}
