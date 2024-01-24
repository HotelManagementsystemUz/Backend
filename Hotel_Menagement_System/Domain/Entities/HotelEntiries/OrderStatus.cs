using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public class OrderStatus:BaseEntity
{

    [Required]
    public string Name { get; set; } = string.Empty;
}
