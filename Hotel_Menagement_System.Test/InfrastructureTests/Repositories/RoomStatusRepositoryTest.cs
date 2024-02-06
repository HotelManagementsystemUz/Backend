using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.HotelEntiries;
using NUnit.Framework.Legacy;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories; 

public class RoomStatusRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> options =
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("RoomStatusDb")
            .Options;

    private ApplicationDbContext _dbContext;
    private RoomStatusRepository _roomStatusRepository;

    [SetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        _roomStatusRepository = new RoomStatusRepository(_dbContext);
    }

    [Test]
    public async Task Test1_AddNewRoomStatus()
    {
        // Arrange
        var roomStatus = new RoomStatus
        {
            Name = "Test"
        };

        // Act
        await _roomStatusRepository.AddAsync(roomStatus);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.RoomStatuses.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_UpdateRoomStatus()
    {
        // Arrange
        var roomStatus = new RoomStatus
        {
            Name = "Test"
        };
        await _roomStatusRepository.AddAsync(roomStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        roomStatus.Name = "UpdatedTest";
        await _roomStatusRepository.UpdateAsync(roomStatus);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedRoomStatus = await _dbContext.RoomStatuses.FindAsync(roomStatus.Id);
        Assert.That(updatedRoomStatus.Name, Is.EqualTo("UpdatedTest"));

    }

    [Test]
    public async Task Test3_DeleteRoomStatus()
    {
        // Arrange
        var roomStatus = new RoomStatus
        {
            Name = "Test"
        };
        await _roomStatusRepository.AddAsync(roomStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        await _roomStatusRepository.DeleteAsync(roomStatus.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.RoomStatuses.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_GetRoomStatusById()
    {
        // Arrange
        var roomStatus = new RoomStatus
        {
            Name = "Test"
        };
        await _roomStatusRepository.AddAsync(roomStatus);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedRoomStatus = await _roomStatusRepository.GetByIdAsync(roomStatus.Id);

        // Assert
        Assert.That(retrievedRoomStatus.Id, Is.EqualTo(roomStatus.Id));
    }

    [Test]
    public async Task Test5_GetAllRoomStatuses()
    {
        // Arrange
        var roomStatus1 = new RoomStatus { Name = "Status1" };
        var roomStatus2 = new RoomStatus { Name = "Status2" };
        await _roomStatusRepository.AddAsync(roomStatus1);
        await _roomStatusRepository.AddAsync(roomStatus2);
        await _dbContext.SaveChangesAsync();

        // Act
        var roomStatuses = await _roomStatusRepository.GetAllAsync();

        // Assert
        Assert.That(roomStatuses.Count, Is.EqualTo(2));
        CollectionAssert.Contains(roomStatuses, roomStatus1);
        CollectionAssert.Contains(roomStatuses, roomStatus2);
    }

}
