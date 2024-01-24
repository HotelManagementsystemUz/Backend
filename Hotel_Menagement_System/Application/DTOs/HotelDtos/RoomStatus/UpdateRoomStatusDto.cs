

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.RoomStatus;

public class UpdateRoomStatusDto:BaseDto
{
    [Required(ErrorMessage = "Xonaning holati nomini kiriting.")]
    public string Name { get; set; } = string.Empty;
}
