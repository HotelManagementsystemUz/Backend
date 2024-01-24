using System.ComponentModel.DataAnnotations;


namespace Domain.Entities.HotelEntiries;

public class RoomType:BaseEntity
{

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int PersonCount { get; set; }
}
