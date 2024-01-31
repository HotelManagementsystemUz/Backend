using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries;


public class Order:BaseEntity
{


    [Required]
    public int GuestId { get; set; }

    [Required]
    public int AdminId { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [ForeignKey("GuestId")]
    public virtual Guest Guest { get; set; } = new Guest();


    [ForeignKey("StatusId")]
    public virtual OrderStatus Status { get; set; }


}
