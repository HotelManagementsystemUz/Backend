using Application.DTOs.HotelDtos.Organization;

namespace Application.Interfaces;

public interface IOrganizationService
{
    Task<List<OrganizationDto>> GetAllAsync();

    Task<OrganizationDto> GetByIdAsync(int id);
    Task AddAsync(AddOrganizationDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateOrganizationDto dto);
    Task<List<OrganizationDto>> Filter(string text);
}
