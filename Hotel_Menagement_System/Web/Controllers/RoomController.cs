using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Room;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "ADMIN, SuperAdmin")]
[Authorize(Roles = IdentityRoles.ADMIN)]


public class RoomController(IRoomService roomService) : ControllerBase
{
    private readonly IRoomService _roomService = roomService;

    [HttpPost("add-room")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddRoom([FromBody] AddRoomDto roomDto)
    {
        try
        {
            await _roomService.AddRoomAsync(roomDto);
            return Ok("Room added successfully");
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("get-all-rooms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllRooms()
    {
        try
        {
            var rooms = await _roomService.GetAllRoomAsync();
            return Ok(rooms);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpGet("get-by-id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetbyIdAsync(int id)
    {
        try
        {
            var room = await _roomService.GetByIdRoomAsync(id);
            return Ok(room);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception  ex)
        {
            return StatusCode(500, $"{ex.Message} Internal server error");
        }
    }
    [HttpPut("update-room")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRoom( [FromBody] UpdateRoomDto updatedRoomDto)
    {
        try
        {

            await _roomService.UpdateRoomAsync(updatedRoomDto);

            return Ok("Room updated successfully");
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal server error");
        }
    }
    [HttpDelete("delete-room")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id < 0)
            {
                return BadRequest("Id 0 dan katta bo'lish kerak");
            }
            await _roomService.DeleteRoomAsync(id);
            return Ok();
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"{ex.Message} Internal server error");
        }
    }


    [HttpGet("pagination-room")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Pagination(int page = 1, int pageSize = 10)
    {
        if (page < 1 || pageSize < 1)
        {
            return BadRequest("Invalid page or pageSize parameters.");
        }

        var rooms = await _roomService.GetAllRoomAsync();

        var totalCount = rooms.Count;
        var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

        if (page > totalPages)
        {
            return BadRequest("Requested page is out of bounds.");
        }

        var organizationPerPage = rooms
            .OrderBy(o => o.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var result = new
        {
            Data = organizationPerPage,
            TotalCount = totalCount,
            TotalPages = totalPages,
            CurrentPage = page
        };

        return Ok(result);
    }
    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> FilterStaff([FromQuery] string searchText)
    {
        try
        {
            var filteredRooms = await _roomService.FilterRooms(searchText);
            return Ok(filteredRooms);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
