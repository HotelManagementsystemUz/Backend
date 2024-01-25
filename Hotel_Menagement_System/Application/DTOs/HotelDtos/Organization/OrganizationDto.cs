namespace Application.DTOs.HotelDtos.Organization;

public class OrganizationDto:BaseDto
{
    public string OrganizationName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Inn { get; set; } = string.Empty;
    public string DerektorFullName { get; set; } = string.Empty;
    public string YuridikAddress { get; set; } = string.Empty;
    public string OtherInformation { get; set; } = string.Empty;
    public DateTime AddedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
