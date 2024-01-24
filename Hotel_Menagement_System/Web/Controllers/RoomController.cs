using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Room;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController(IRoomService roomService) : ControllerBase
{
    private readonly IRoomService _roomService = roomService;

    [HttpPost("AddRoom")]
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

    [HttpGet("GetAllRooms")]
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
}
