﻿namespace Application.DTOs.HotelDtos.Room;

public class UpdateRoomDto:BaseDto
{
    [Required(ErrorMessage = "Xonaning raqamini kiriting.")]
    public int Number { get; set; }

    [Required(ErrorMessage = "Xonaning narxini kiriting.")]
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;


    [Required(ErrorMessage = "Xonaning shaxs sonini kiriting.")]
    public int PersonCount { get; set; }

    [Required(ErrorMessage = "Xonaning turi identifikatorini kiriting.")]
    public int RoomTypeId { get; set; }

    [Required(ErrorMessage = "Xonaning holati identifikatorini kiriting.")]
    public int RoomStatusId { get; set; }

    //// Xonaning turi ma'lumotlari
    //public RoomTypeDto RoomType { get; set; }

    //// Xonaning holati ma'lumotlari
    //public RoomStatusDto RoomStatus { get; set; }
}
