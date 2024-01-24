using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.Guest;

public class AddGuestDto
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

    [Required(ErrorMessage = "Iltimos, telefon raqamingizni kiriting.")]
    [StringLength(15, ErrorMessage = "Telefon raqami 15 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, passport ma'lumotlaringizni kiriting.")]
    [StringLength(60, ErrorMessage = "Passport ma'lumotlari 60 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Passport { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tug'ilgan kuningizni kiriting.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Iltimos, berilgan kuningizni kiriting.")]
    public DateTime DateOfIssue { get; set; }

    [StringLength(500, ErrorMessage = "Manzilingiz 500 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tashkilotingizni nomini kiriting.")]
    [StringLength(50, ErrorMessage = "Tashkilot nomi 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string OrganizationName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, kim tomonidan berilganligini kiriting.")]
    [StringLength(50, ErrorMessage = "Kim tomonidan berilganligi 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string GivenByWhom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, fuqorolikni kiriting.")]
    [StringLength(50, ErrorMessage = "Fuqorolik 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Citizenship { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tavsifni kiriting.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, tashkilot nomini kiriting.")]
    [StringLength(50, ErrorMessage = "Tashkilot nomi 50 ta belgidan ko'p bo'lishi mumkin emas.")]
    public string Organization { get; set; } = string.Empty;

    [Required(ErrorMessage = "Iltimos, jinsingizni tanlang.")]
    public Gender Gender { get; set; }
}
