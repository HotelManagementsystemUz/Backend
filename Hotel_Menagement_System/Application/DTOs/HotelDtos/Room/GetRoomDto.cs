using Application.DTOs.HotelDtos.RoomStatus;
using Application.DTOs.HotelDtos.RoomType;

namespace Application.DTOs.HotelDtos.Room;

public class GetRoomDto : BaseDto
{
    [Required(ErrorMessage = "Enter the room number.")]
    public int Number { get; set; }

    [Required(ErrorMessage = "Enter the room price.")]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;


    [Required(ErrorMessage = "Xonaning shaxs sonini kiriting.")]
    public int PersonCount { get; set; }

    [Required(ErrorMessage = "Enter the room type.")]
    public RoomTypeDto RoomType { get; set; } // Assuming RoomTypeDto exists

    [Required(ErrorMessage = "Enter the room status.")]
    public RoomStatusDto RoomStatus { get; set; } // Assuming RoomStatusDto exists
}