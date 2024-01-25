using Application.DTOs.HotelDtos.Admin;

namespace Application.Interfaces;

public interface IAdminService
{
    Task<List<AdminDto>> GetAllAdminsAsync();
    Task<AdminDto> GetByIdAdminAsync(int id);
    Task AddAdminAsync(AddAdminDto dto);
    Task DeleteAdminAsync(int id);
    Task UpdateAdminAsync(UpdateAdminDto dto);
}
