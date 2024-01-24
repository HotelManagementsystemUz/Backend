using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public abstract class BaseDto
{
    [Key, Required]
    public int Id { get; set; }
}