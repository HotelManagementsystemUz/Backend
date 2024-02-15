
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities.HotelEntiries;

public class Room:BaseEntity
{

    [Required]
    public int Number { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;


    [Required(ErrorMessage = "Xonaning shaxs sonini kiriting.")]
    public int PersonCount { get; set; }

    [Required]
    public int RoomTypeId { get; set; }

    [Required]
    public int RoomStatusId { get; set; }

    [ForeignKey("RoomTypeId")]
    public virtual RoomType RoomType { get; set; }

    [ForeignKey("RoomStatusId")]
    public virtual RoomStatus RoomStatus { get; set; }

}
