using Application.DTOs.HotelDtos.Guest;
using Application.DTOs.HotelDtos.OrderStatus;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.Order;

public class OrderDto:BaseDto
{
    [Required(ErrorMessage = "Mehmonni tanlanganligingizni kiriting.")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Adminni tanlanganligingizni kiriting.")]
    public int AdminId { get; set; }

    [Required(ErrorMessage = "Holatni tanlanganligingizni kiriting.")]
    public int StatusId { get; set; }

    [Required(ErrorMessage = "Boshlang'ich sana ni kiriting.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Tugash sanasini kiriting.")]
    public DateTime EndDate { get; set; }

    // Mehmonga oid ma'lumotlar
    public GuestDto Guest { get; set; } = new GuestDto();


    // Buyurtma holati ma'lumotlari
    public OrderStatusDto Status { get; set; } = new OrderStatusDto();
}
