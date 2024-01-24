using Application.DTOs.HotelDtos.Staff;

namespace Application.Interfaces;

public interface IStaffService
{
    Task<List<StaffDto>> GetAllStaffAsync();
    Task<StaffDto> GetByIdStaff(int id);
    Task AddAsync(AddStaffDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateStaffDto dto);
}
