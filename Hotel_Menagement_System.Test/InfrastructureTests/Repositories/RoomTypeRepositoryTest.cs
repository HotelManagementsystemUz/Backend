using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Menagement_System.Test.InfrastructureTests.Repositories;

[TestFixture]

public class RoomTypeRepositoryTest
{

    private DbContextOptions<ApplicationDbContext> options =
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("RoomTypeDb")
            .Options;

    private ApplicationDbContext _dbContext;
    private RoomTypeRepository _typeRepository;

    [SetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        _typeRepository = new RoomTypeRepository(_dbContext);
    }

    [Test]
    public async Task Test1_AddNewRoomStatus()
    {
        // Arrange
        var roomType = new RoomType
        {
            Name = "Test",
            PersonCount = 4
        };

        // Act
        await _typeRepository.AddAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.RoomTypes.Count(), Is.EqualTo(1));
    }
    [Test]
    public async Task Test2_UpdateNewRoomStatus()
    {
        // Arrange
        var roomType = new RoomType
        {
            Name = "Test",
            PersonCount = 4
        };
        await _typeRepository.AddAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Act
        roomType.PersonCount = 6;
        await _typeRepository.UpdateAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedRoomType = await _typeRepository.GetByIdAsync(roomType.Id);
        Assert.That(updatedRoomType.PersonCount, Is.EqualTo(6));
    }
    [Test]
    public async Task Test3_GetAllRoomTypes()
    {
        // Arrange
        var roomTypes = new List<RoomType>
{
    new RoomType { Name = "Single", PersonCount = 1 },
    new RoomType { Name = "Double", PersonCount = 2 },
    new RoomType { Name = "Suite", PersonCount = 4 }
};

        foreach (var roomType in roomTypes)
        {
            await _typeRepository.AddAsync(roomType);
        }
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedRoomTypes = await _typeRepository.GetAllAsync();

        // Assert
        Assert.That(retrievedRoomTypes.Count , Is.EqualTo(3));
    }

    [Test]
    public async Task Test4_GetRoomTypeById()
    {
        // Arrange
        var roomType = new RoomType { Name = "Suite", PersonCount = 4 };
        await _typeRepository.AddAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedRoomType = await _typeRepository.GetByIdAsync(roomType.Id);

        // Assert
      
        Assert.That(roomType.PersonCount, Is.EqualTo(retrievedRoomType.PersonCount));
    }

    [Test]
    public async Task Test5_DeleteRoomType()
    {
        // Arrange
        var roomType = new RoomType { Name = "Suite", PersonCount = 4 };
        await _typeRepository.AddAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Act
        await _typeRepository.DeleteAsync(1);
        await _dbContext.SaveChangesAsync();

        var retrievedRoomType = await _typeRepository.GetByIdAsync(roomType.Id);

        // Assert
        Assert.That(retrievedRoomType, Is.EqualTo(null));
    }


}
