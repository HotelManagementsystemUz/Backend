using Domain.Enums;
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
    [MaxLength(70)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength (15)]
    public string PhoneNumber {  get; set; } = string.Empty;
    //[Required]
    //[MaxLength(30)]
    //[MinLength(4)]
    //public string Password { get; set; } = string.Empty;

    public Roles Roles { get; set; } = Roles.Admin;

    [Required]
    [StringLength(500)]
    public string Address { get; set; } = string.Empty;
}
