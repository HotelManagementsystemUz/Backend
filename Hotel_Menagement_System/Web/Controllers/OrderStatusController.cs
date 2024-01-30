using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.OrderStatus;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN, SuperAdmin")]
public class OrderStatusController(IOrderStatusService orderStatusService) : ControllerBase
{
    private readonly IOrderStatusService _orderStatusService = orderStatusService;

    [HttpPost("add-orderstatus")]

    public async Task<IActionResult> AddOrderStatusAsync(AddOrderStatusDto dto)
    {
        try
        {
            await _orderStatusService.AddOrderStatusAsync(dto);
            return Ok();
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("get-all-orderstatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var orderStatuses = await _orderStatusService.GetAllOrderStatusAsync();
            return Ok(orderStatuses);
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
    [HttpGet("get-by-id-orderstatus")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var orderstatus = await _orderStatusService.GetByIdOrderStatusAsync(id);
            return Ok(orderstatus);
        }
        catch(CustomException ex)
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
    [HttpPut("update-orderstatus")]
    public async Task<IActionResult> UpdateOrderstatus(UpdateOrderStatusDto dto)
    {
        try
        {
            await _orderStatusService.UpdateOrderStatusAsync(dto);
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
    [HttpDelete("delete-orderstatus")]
    public  async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _orderStatusService.DeleteOrderStatusAsync(id);
            return Ok();
        }
        catch(CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
