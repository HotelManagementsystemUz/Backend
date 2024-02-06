using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class OrderRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> _options;
    private ApplicationDbContext _dbContext;
    private OrderRepository _orderRepository;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("OrderDb")
            .Options;

        _dbContext = new ApplicationDbContext(_options);
        _orderRepository = new OrderRepository(_dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task Test1_AddNewOrder()
    {
        // Arrange
        var order = new Order
        {
            GuestId = 1,
            AdminId = "admin123",
            StatusId = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };

        // Act
        await _orderRepository.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Orders.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_GetOrderById()
    {
        // Arrange
        var order = new Order
        {
            GuestId = 1,
            AdminId = "admin123",
            StatusId = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };
        await _orderRepository.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedOrder = await _orderRepository.GetByIdAsync(order.Id);

        // Assert
        Assert.That(retrievedOrder.GuestId, Is.EqualTo(order.GuestId));
        Assert.That(retrievedOrder.AdminId, Is.EqualTo(order.AdminId));
    }

    [Test]
    public async Task Test3_DeleteOrder()
    {
        // Arrange
        var order = new Order
        {
            GuestId = 1,
            AdminId = "admin123",
            StatusId = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };
        await _orderRepository.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        // Act
        await _orderRepository.DeleteAsync(order.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Orders.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_UpdateOrder()
    {
        // Arrange
        var order = new Order
        {
            GuestId = 1,
            AdminId = "admin123",
            StatusId = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1)
        };
        await _orderRepository.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        // Act
        order.GuestId = 2; // Change guest ID
        await _orderRepository.UpdateAsync(order);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedOrder = await _orderRepository.GetByIdAsync(order.Id);
        Assert.That(updatedOrder.GuestId, Is.EqualTo(2));
    }

    [Test]
    public async Task Test5_GetAllOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { GuestId = 1, AdminId = "admin123", StatusId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) },
            new Order { GuestId = 2, AdminId = "admin123", StatusId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) }
        };
        foreach (var order in orders)
        {
            await _orderRepository.AddAsync(order);
        }
        await _dbContext.SaveChangesAsync();

        // Act
        var allOrders = await _orderRepository.GetAllAsync();

        // Assert
        Assert.That(allOrders.Count(), Is.EqualTo(2));
    }
}
