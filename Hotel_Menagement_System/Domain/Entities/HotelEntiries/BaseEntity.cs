

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public class BaseEntity
{
    [Key, Required]
    public int Id { get; set; }
}
