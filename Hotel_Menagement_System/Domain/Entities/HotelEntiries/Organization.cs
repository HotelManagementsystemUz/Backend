using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public  class Organization:BaseEntity
{
    [Required, MinLength(5) , MaxLength(200)]
    public string OrganizationName { get; set; } = string.Empty;
    [Required, MinLength(8), MaxLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required, MinLength(2), MaxLength(200)]

    public string Inn { get; set; } = string.Empty;
    [Required, MinLength(2), MaxLength(200)]

    public string DerektorFullName { get; set; } = string.Empty;
    [Required, MinLength(2), MaxLength(200)]

    public string YuridikAddress { get; set; } = string.Empty;
    [Required, MinLength(3), MaxLength(200)]

    public string OtherInformation { get; set; } = string.Empty;
    public DateTime AddedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; } =DateTime.Now;
}

