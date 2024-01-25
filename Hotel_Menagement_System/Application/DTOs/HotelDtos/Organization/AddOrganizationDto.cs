namespace Application.DTOs.HotelDtos.Organization;


public class AddOrganizationDto
{
    [Required(ErrorMessage = "Lavozim nomini kiriting."), MinLength(5), MaxLength(200)]
    public string? OrganizationName { get; set; }

    [Required(ErrorMessage = "Telefon raqamini kiriting."), MinLength(8), MaxLength(15)]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "INN ni kiriting."), MinLength(2), MaxLength(200)]
    public string? Inn { get; set; }

    [Required(ErrorMessage = "Direktor to'liq ismini kiriting."), MinLength(2), MaxLength(200)]
    public string? DerektorFullName { get; set; }

    [Required(ErrorMessage = "Yuridik manzilni kiriting."), MinLength(2), MaxLength(200)]
    public string? YuridikAddress { get; set; }

    [Required(ErrorMessage = "Boshqa ma'lumotlarni kiriting."), MinLength(3), MaxLength(200)]
    public string? OtherInformation { get; set; }
}
