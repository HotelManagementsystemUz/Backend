﻿using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Admin;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController(IAdminService adminService) : ControllerBase
{
    private readonly IAdminService _adminService = adminService;

    [HttpPost("add-admin")] 
    public async Task<IActionResult> AddAdmin(AddAdminDto dto)
    {
        try
        {
            await _adminService.AddAdminAsync(dto);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("get-all-admin")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }
        catch(NotFoundException)
        {
            return NoContent();
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var admins = await _adminService.GetByIdAdminAsync(id);
            return Ok(admins);
        }
        catch (NotFoundException)
        {
            return NoContent();
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

    [HttpPut("update-admin")]
    public async Task<IActionResult> UpdateAdmin(UpdateAdminDto dto)
    {
        try
        {
            await _adminService.UpdateAdminAsync(dto);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("delete-admin/{id}")]
    public async Task<IActionResult> DeleteAdminAsync(int id)
    {
        try
        {
            await _adminService.DeleteAdminAsync(id);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
