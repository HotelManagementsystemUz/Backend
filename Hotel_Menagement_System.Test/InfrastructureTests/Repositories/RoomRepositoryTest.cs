using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class RoomRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> _options;
    private ApplicationDbContext _dbContext;
    private RoomRepository _roomRepository;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase("TestDatabase")
        .Options;

        _dbContext = new ApplicationDbContext(_options);
        _roomRepository = new RoomRepository(_dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task Test1_AddNewRoom()
    {
        // Arrange
        var room = new Room
        {
            Number = 101,
            Price = 50.0m,
            Description = "Test Room",
            RoomTypeId = 1, 
            RoomStatusId = 1
        };

        // Act
        await _roomRepository.AddAsync(room);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Rooms.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_GetRoomById()
    {
        // Arrange
        var room = new Room
        {
            Number = 101,
            Price = 50.0m,
            Description = "Test Room",
            RoomTypeId = 1, 
            RoomStatusId = 1 
        };
        await _roomRepository.AddAsync(room);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedRoom = await _roomRepository.GetByIdAsync(room.Id);

        // Assert
        Assert.That(room.Number, Is.EqualTo(retrievedRoom.Number));
        Assert.That(room.Price, Is.EqualTo(retrievedRoom.Price));
        Assert.That(room.Description, Is.EqualTo(retrievedRoom.Description));
        Assert.That(room.RoomTypeId, Is.EqualTo(retrievedRoom.RoomTypeId));
        Assert.That(room.RoomStatusId, Is.EqualTo(retrievedRoom.RoomStatusId));
    }

    [Test]
    public async Task Test3_UpdateRoom()
    {
        // Arrange
        var room = new Room
        {
            Number = 101,
            Price = 50.0m,
            Description = "Test Room",
            RoomTypeId = 1, 
            RoomStatusId = 1 
        };
        await _roomRepository.AddAsync(room);
        await _dbContext.SaveChangesAsync();

        // Act
        room.Number = 102;
        room.Price = 60.0m;
        room.Description = "Updated Room";
        await _roomRepository.UpdateAsync(room);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedRoom = await _roomRepository.GetByIdAsync(room.Id);
        Assert.That(102, Is.EqualTo(updatedRoom.Number));
        Assert.That(60.0m, Is.EqualTo(updatedRoom.Price));
        Assert.That("Updated Room", Is.EqualTo(updatedRoom.Description));
    }

    [Test]
    public async Task Test4_DeleteRoom()
    {
        // Arrange
        var room = new Room
        {
            Number = 101,
            Price = 50.0m,
            Description = "Test Room",
            RoomTypeId = 1, 
            RoomStatusId = 1
        };
        await _roomRepository.AddAsync(room);
        await _dbContext.SaveChangesAsync();

        // Act
        await _roomRepository.DeleteAsync(room.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Rooms.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test5_GetAllRooms()
    {
        // Arrange
        var room1 = new Room
        {
            Number = 101,
            Price = 50.0m,
            Description = "Test Room 1",
            RoomTypeId = 1, 
            RoomStatusId = 1 
        };

        var room2 = new Room
        {
            Number = 102,
            Price = 60.0m,
            Description = "Test Room 2",
            RoomTypeId = 2, 
            RoomStatusId = 2 
        };

        await _roomRepository.AddAsync(room1);
        await _roomRepository.AddAsync(room2);
        await _dbContext.SaveChangesAsync();

        // Act
        var allRooms = await _roomRepository.GetAllAsync();

        // Assert
        Assert.That(allRooms.Any(r => r.Number == 101));
        Assert.That(allRooms.Any(r => r.Number == 102));
    }
}
