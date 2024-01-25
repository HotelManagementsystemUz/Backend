using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public  class Organization:BaseEntity
{
    [Required, MinLength(5) , MaxLength(200)]
    public string OrganizationName { get; set; } = string.Empty;
    [Required, MinLength(5), MaxLength(200)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string INN = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string DerektorI_F_Sh = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string Yuridik_Address = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string OtherInformation = string.Empty;
    public DateTime AddedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
