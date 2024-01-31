using Application.DTOs.HotelDtos.Guest;
using Application.DTOs.HotelDtos.Room;
using Domain.Entities.HotelEntiries;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<List<GuestDto>> GetAllAsync();
    Task<GuestDto> GetByIdAsync(int id);
    Task AddAsync(AddGuestDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateGuestDto dto);
    Task<List<GuestDto>> FilterGuests(string searchText);
    Task<string> Summa(int guestId);
}
