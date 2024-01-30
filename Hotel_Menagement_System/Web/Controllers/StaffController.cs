using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Staff;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = IdentityRoles.ADMIN)]
[Authorize(Roles = IdentityRoles.SUPER_ADMIN)]
public class StaffController(IStaffService staffService) : ControllerBase
{
    public IStaffService _staffService { get; } = staffService;



    [HttpPost("add-staff")]
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
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var staff =  await _staffService.GetByIdStaff(id);
            return Ok(staff); 
        }
        catch(NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("get-all-staff")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var staffs = await _staffService.GetAllStaffAsync();
            if(staffs == null)
            {
                return NoContent();
            }
            return Ok(staffs);
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update-staff")]
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
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        }

    }
}
