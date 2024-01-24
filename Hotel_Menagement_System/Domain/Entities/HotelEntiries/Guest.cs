

using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities.HotelEntiries;

public class Guest:BaseEntity
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
    [StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string Passport { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime DateOfIssue { get; set; }

    [StringLength(500)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string OrganizationName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]

    //KIM TOMONIDAN BERILGAN
    public string GIVENBYWHOM { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    //Fuqorolik
    public string CITIZENSHIP { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Organization { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public Gender Gender { get; set; } 
}
