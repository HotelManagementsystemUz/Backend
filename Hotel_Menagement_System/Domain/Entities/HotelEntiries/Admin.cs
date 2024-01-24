using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;

public class Admin:BaseEntity
{


    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } =string.Empty;

    [Required]
    [StringLength(500)]
    public string Address { get; set; } = string.Empty;
}
