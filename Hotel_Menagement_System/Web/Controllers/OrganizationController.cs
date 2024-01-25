﻿using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Organization;
using Domain.Entities.HotelEntiries;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationController(IOrganizationService organizationService) : ControllerBase
{
    private readonly IOrganizationService _organizationService = organizationService;


    [HttpPost("add-organization")]
    public async Task<IActionResult> AddAsync(AddOrganizationDto dto)
    {
        try
        {
            await _organizationService.AddAsync(dto);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
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
    [HttpGet("get-all-organization")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var organizations = await _organizationService.GetAllAsync();
            return Ok(organizations);
        }
        catch(CustomException ex)
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

    [HttpGet("get-by-id-organization")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var organizations = await _organizationService.GetByIdAsync(id);
            return Ok(organizations);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
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
    [HttpPut("update-organization")]
    public async Task<IActionResult> UpdateOrganization(UpdateOrganizationDto dto)
    {
        try
        {
            await _organizationService.UpdateAsync(dto);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
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


    [HttpDelete("delete-organization")]
    public async Task<IActionResult> DeleteOrganization(int id)
    {
        try
        {
            await _organizationService.DeleteAsync(id);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
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

    [HttpGet("pagination-organization")]
    public async Task<IActionResult> Pagination(int page = 1, int pageSize = 10)
    {
        if (page < 1 || pageSize < 1)
        {
            return BadRequest("Invalid page or pageSize parameters.");
        }

        var organizations = await _organizationService.GetAllAsync();

        var totalCount = organizations.Count;
        var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

        if (page > totalPages)
        {
            return BadRequest("Requested page is out of bounds.");
        }

        var organizationPerPage = organizations
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


    [HttpGet("filltet-organizations")]
    public async Task<IActionResult> FilterOrganizations(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            return BadRequest("Search text is required.");
        }

        try
        {
            var filteredOrganizations = await _organizationService.Filter(searchText);
            return Ok(filteredOrganizations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}