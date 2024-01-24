

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.Admin;

public class UpdateAdminDto:BaseDto
{
    [Required(ErrorMessage = "Iltimos, ismingizni kiriting.")]
    [StringLength(50, ErrorMessage = "Ismingiz 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, familiyangizni kiriting.")]
    [StringLength(50, ErrorMessage = "Familiyangiz 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, manzilingizni kiriting.")]
    [StringLength(500, ErrorMessage = "Manzilingiz 500 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Address { get; set; } = string.Empty;
}
