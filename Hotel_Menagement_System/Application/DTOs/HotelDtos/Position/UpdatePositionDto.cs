

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.Position;

public class UpdatePositionDto:BaseDto
{
    [Required(ErrorMessage = "Lavozim nomini kiriting.")]
    public string Name { get; set; } = string.Empty;
}
