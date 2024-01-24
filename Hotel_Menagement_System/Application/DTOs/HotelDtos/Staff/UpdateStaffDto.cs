using Application.DTOs.HotelDtos.Position;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.Staff;

public class UpdateStaffDto:BaseDto
{
    [Required(ErrorMessage = "Iltimos, ismingizni kiriting.")]
    [StringLength(50, ErrorMessage = "Ismingiz 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, familiyangizni kiriting.")]
    [StringLength(50, ErrorMessage = "Familiyangiz 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, otangizning ismini kiriting.")]
    [StringLength(50, ErrorMessage = "Otangizning ismi 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string FatherName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, foydalanuvchi nomini kiriting.")]
    [StringLength(50, ErrorMessage = "Foydalanuvchi nomi 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, elektron pochtangizni kiriting.")]
    [StringLength(60, ErrorMessage = "Elektron pochta 60 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, lavozimingiz identifikatorini kiriting.")]
    public int PositionId { get; set; }

    [Required(ErrorMessage = "Iltimos, telefon raqamingizni kiriting.")]
    [StringLength(15, ErrorMessage = "Telefon raqami 15 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, jinsingizni kiriting.")]
    [StringLength(50, ErrorMessage = "Jinsingiz 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Gender { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tug'ilgan kuningizni kiriting.")]
    public DateTime BirthDate { get; set; }

    [StringLength(500, ErrorMessage = "Manzilingiz 500 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tavsifni kiriting.")]
    [StringLength(1500, ErrorMessage = "Tavsif 1500 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Description { get; set; } = string.Empty;

    //[Required(ErrorMessage = "Iltimos, lavozimingiz identifikatorini kiriting.")]

    //// Lavozim ma'lumotlari
    //public PositionDto Position { get; set; } = new PositionDto();
}

