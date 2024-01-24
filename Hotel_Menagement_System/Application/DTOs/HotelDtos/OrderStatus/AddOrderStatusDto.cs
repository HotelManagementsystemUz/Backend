

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.OrderStatus;

public class AddOrderStatusDto
{
    [Required(ErrorMessage = "Buyurtma holati nomini kiriting.")]
    public string Name { get; set; } = string.Empty;
}
