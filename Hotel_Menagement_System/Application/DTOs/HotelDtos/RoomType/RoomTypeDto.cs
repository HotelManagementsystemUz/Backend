﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HotelDtos.RoomType;

public class RoomTypeDto:BaseDto
{
    [Required(ErrorMessage = "Xonaning turi nomini kiriting.")]
    public string Name { get; set; } = string.Empty;

}
