
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;


namespace Domain.Entities.HotelEntiries;


public class Staff:BaseEntity
{
   

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FatherName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int PositionId { get; set; }

    [Required]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [StringLength(500)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(1500)]
    public string Description { get; set; } = string.Empty;

    [ForeignKey("PositionId")]
    public virtual Position Position { get; set; }

}
