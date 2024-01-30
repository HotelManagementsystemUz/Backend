using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.RoomType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = IdentityRoles.ADMIN)]
[Authorize(Roles = IdentityRoles.SUPER_ADMIN)]
public class RoomTypeController(IRoomTypeService roomTypeService) : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService = roomTypeService;


    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypesAsync();

            if (roomTypes == null || !roomTypes.Any())
            {
                return NoContent();
            }

            return Ok(roomTypes);
        }
        catch (CustomException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var roomType = await _roomTypeService.GetByIdRoomTypesAsync(id);
            if (roomType is null)
            {
                return NoContent();
            }
            return Ok(roomType);
        }
        catch (CustomException ex)
        {
            return NotFound($"{ex.Message} {id} - id da RoomType topilmadi");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(AddRoomTypeDto dto)
    {
        try
        {
            if (dto is null)
            {
                return NoContent();
            }
            await _roomTypeService.AddRoomType(dto);
            return Ok("RoomType has been successfully added");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest($"Invalid request: {ex.Message}");
        }
        catch (CustomException ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
        catch (NotFoundException ex)
        {
            return NotFound($"Not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
    [HttpPut]

    public async Task<IActionResult> UpdateAsync(UpdateRoomTypeDto dto)
    {
        try
        {
            if (dto is null)
            {
                return NoContent();
            }
            await _roomTypeService.UpdateRoomType(dto);
            return Ok("RoomType successfully updated");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest($"Invalid request: {ex.Message}");
        }
        catch (CustomException ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
        catch (NotFoundException ex)
        {
            return NotFound($"Not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                return NoContent();
            }

            var roomType = await _roomTypeService.GetByIdRoomTypesAsync(id);

            if (roomType == null)
            {
                return NoContent();
            }

            await _roomTypeService.DeleteRoomTypeAsync(id);

            return Ok("RoomType successfully deleted");
        }
        catch (CustomException)
        {
            return NotFound(); // Use NotFound for 404 Not Found
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
