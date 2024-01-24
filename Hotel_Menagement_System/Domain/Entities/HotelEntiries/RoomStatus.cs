using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HotelEntiries
{
    public class RoomStatus : BaseEntity 
    { 
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
