using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.RoomStatus;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = IdentityRoles.ADMIN)]

public class RoomStatusController(IRoomStatusService roomStatusService) : ControllerBase
{
    private readonly IRoomStatusService _roomStatusService = roomStatusService;


    [HttpPost("add-room-status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddRoomStatusAsync(AddRoomStatusDto dto)
    {
        try
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "RoomStatusDto is null");
            }

            await _roomStatusService.AddRoomStatusAsync(dto);

            return Ok("RoomStatus added successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CustomException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal Server Error");
        }
    }

    [HttpDelete("get-by-id-roomstatus{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id is null or invalid");
            }

            await _roomStatusService.DeleteRoomStatusAsync(id);

            return Ok($"RoomStatus with Id {id} deleted successfully");
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("get-all-rooms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllRoomStatusAsync()
    {
        try
        {
            var roomStatuses = await _roomStatusService.GetAllRoomStatusAsync();
            return Ok(roomStatuses);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal Server Error");
        }
    }

    [HttpGet("get-by-id-roomstatus{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdRoomStatusAsync(int id)
    {
        try
        {
            var roomStatus = await _roomStatusService.GetByIdRoomStatusAsync(id);
            return Ok(roomStatus);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal Server Error");
        }
    }

    [HttpPut("update-roomstatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRoomStatusAsync(UpdateRoomStatusDto dto)
    {
        try
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "RoomStatusDto is null");
            }

            await _roomStatusService.UpdateRoomStatusAsync(dto);
            return Ok("RoomStatus updated successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal Server Error");
        }
    }


}
