
using Application.Common.Constants;
using Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN, SuperAdmin")]

public class GuestController : ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService ?? throw new ArgumentNullException(nameof(guestService));
    }

    [HttpPost("add-guest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddGuest([FromBody] AddGuestDto dto)
    {
        try
        {
            await _guestService.AddAsync(dto);
            return Ok("Guest added successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("get-all-guests")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllGuests()
    {
        try
        {
            var guests = await _guestService.GetAllAsync();
            return Ok(guests);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("get-by-id-guest/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetGuestById(int id)
    {
        try
        {
            var guest = await _guestService.GetByIdAsync(id);
            return Ok(guest);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("update-guest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateGuest(UpdateGuestDto dto)
    {
        try
        {
            await _guestService.UpdateAsync(dto);
            return Ok($"Guest updated successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("delete-guest/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteGuest(int id)
    {
        try
        {
            await _guestService.DeleteAsync(id);
            return Ok($"Guest with ID {id} deleted successfully");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("all-summa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSumma(int guestId)
    {
        try
        {
            var result = await _guestService.Summa(guestId);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
        }
    }


    [HttpGet("pagination-guest")]
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

        var guests = await _guestService.GetAllAsync();

        var totalCount = guests.Count;
        var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

        if (page > totalPages)
        {
            return BadRequest("Requested page is out of bounds.");
        }

        var organizationPerPage = guests
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
    public async Task<IActionResult> FilterGuests([FromQuery] string searchText)
    {
        try
        {
            var filteredGuests = await _guestService.FilterGuests(searchText);
            return Ok(filteredGuests); 
        }
        catch(NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}"); 
        }
    }
}
