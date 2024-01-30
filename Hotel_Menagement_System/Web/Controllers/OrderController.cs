using Application.Common.Constants;
using Application.Common.Exceptions;
using Application.DTOs.HotelDtos.Order;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN, SuperAdmin")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost("add-order")]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderDto orderDto)
    {
        try
        {
            await _orderService.AddOrderAsync(orderDto);
            return Ok("Order added successfully");
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

    [HttpDelete("delete-order{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        try
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok("Order deleted successfully");
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

    [HttpGet("get-all-orders")]
    public async Task<IActionResult> GetAllOrders()
    {
        try
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        catch (CustomException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("get-by-id-order/{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        try
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        catch (CustomException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("update-order")]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto orderDto)
    {
        try
        {
            await _orderService.UpdateOrderAsync(orderDto);
            return Ok("Order updated successfully");
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
}

