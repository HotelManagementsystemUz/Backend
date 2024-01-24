

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public class Position:BaseEntity
{

    [Required]
    public string Name { get; set; }
}
