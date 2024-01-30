using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Position;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN, SuperAdmin")]

public class PositionController(IPositionService positionService) : ControllerBase
{
    private readonly IPositionService _positionService = positionService;

    [HttpGet("get-all-positions")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var positions = await _positionService.GetAllPositionsAsync();

            if (positions.Count == 0)
            {
                return NoContent();
            }

            return Ok(positions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("get-by-id-position/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var position = await _positionService.GetPositionByIdAsync(id);

            if (position is null)
            {
                return NoContent();
            }

            return Ok(position);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("add-position")]
    public async Task<IActionResult> AddPosition([FromBody] AddPositionDto dto)
    {
        try
        {
            await _positionService.AddPosition(dto);
            return Ok("Position added successfully");
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
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("update-position")]
    public async Task<IActionResult> UpdatePosition([FromBody] UpdatePositionDto dto)
    {
        try
        {
            await _positionService.UpdatePosition(dto);
            return Ok("Position updated successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("delete-position{id}")]
    public async Task<IActionResult> DeletePositionById(int id)
    {
        try
        {
            await _positionService.DeletePositionByIdAsync(id);
            return Ok($"Position with Id {id} deleted successfully");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }



}
