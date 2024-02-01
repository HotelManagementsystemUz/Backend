using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Staff;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN, SuperAdmin")]
public class StaffController(IStaffService staffService) : ControllerBase
{
    public IStaffService _staffService { get; } = staffService;



    [HttpPost("add-staff")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddStaffAsync(AddStaffDto dto)
    {
        try
        {
            await _staffService.AddAsync(dto);
            return Ok();
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
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("get-by-id{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var staff = await _staffService.GetByIdStaff(id);
            return Ok(staff);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("get-all-staff")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var staffs = await _staffService.GetAllStaffAsync();
            if (staffs == null)
            {
                return NoContent();
            }
            return Ok(staffs);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update-staff")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(UpdateStaffDto dto)
    {
        try
        {
            await _staffService.UpdateAsync(dto);
            return Ok();
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
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("delete-staff{id}")]
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
            await _staffService.DeleteAsync(id);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        }

    }

    [HttpGet("pagination-staff")]
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

        var staffs = await _staffService.GetAllStaffAsync();

        var totalCount = staffs.Count;
        var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

        if (page > totalPages)
        {
            return BadRequest("Requested page is out of bounds.");
        }

        var organizationPerPage = staffs
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
            var filteredStaff = await _staffService.FilterStaff(searchText);
            return Ok(filteredStaff);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }


    }
}
