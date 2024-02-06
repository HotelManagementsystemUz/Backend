using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class OrderStatusRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> options =
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("OrderStatusDb")
            .Options;

    private ApplicationDbContext _dbContext;
    private OrderStatusRepository _orderStatusRepository;

    [SetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        _orderStatusRepository = new OrderStatusRepository(_dbContext);
    }

    [Test]
    public async Task Test1_AddNewOrderStatus()
    {
        // Arrange
        var orderStatus = new OrderStatus
        {
            Name = "Test"
        };

        // Act
        await _orderStatusRepository.AddAsync(orderStatus);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.OrderStatuses.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_UpdateOrderStatus()
    {
        // Arrange
        var orderStatus = new OrderStatus
        {
            Name = "Test"
        };
        await _orderStatusRepository.AddAsync(orderStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        orderStatus.Name = "UpdatedTest";
        await _orderStatusRepository.UpdateAsync(orderStatus);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedOrderStatus = await _dbContext.OrderStatuses.FindAsync(orderStatus.Id);
        Assert.That(updatedOrderStatus.Name, Is.EqualTo("UpdatedTest"));
    }

    [Test]
    public async Task Test3_DeleteOrderStatus()
    {
        // Arrange
        var orderStatus = new OrderStatus
        {
            Name = "Test"
        };
        await _orderStatusRepository.AddAsync(orderStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        await _orderStatusRepository.DeleteAsync(orderStatus.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.OrderStatuses.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_GetOrderStatusById()
    {
        // Arrange
        var orderStatus = new OrderStatus
        {
            Name = "Test"
        };
        await _orderStatusRepository.AddAsync(orderStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedOrderStatus = await _orderStatusRepository.GetByIdAsync(orderStatus.Id);

        // Assert
        Assert.That(retrievedOrderStatus.Id, Is.EqualTo(orderStatus.Id));
    }

    [Test]
    public async Task Test5_GetAllOrderStatuses()
    {
        // Arrange
        var orderStatus1 = new OrderStatus { Name = "Status1" };
        var orderStatus2 = new OrderStatus { Name = "Status2" };
        await _orderStatusRepository.AddAsync(orderStatus1);
        await _orderStatusRepository.AddAsync(orderStatus2);
        await _dbContext.SaveChangesAsync();

        // Act
        var orderStatuses = await _orderStatusRepository.GetAllAsync();

        // Assert
        Assert.That(orderStatuses.Count, Is.EqualTo(2));
    }
}
