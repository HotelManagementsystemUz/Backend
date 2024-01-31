
namespace Application.DTOs.HotelDtos.Order;

public class AddOrderDto
{
    [Required(ErrorMessage = "Mehmonni tanlanganligingizni kiriting.")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Adminni tanlanganligingizni kiriting.")]
    public string AdminId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Holatni tanlanganligingizni kiriting.")]
    public int StatusId { get; set; }

    [Required(ErrorMessage = "Boshlang'ich sana ni kiriting.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Tugash sanasini kiriting.")]
    public DateTime EndDate { get; set; }

}
