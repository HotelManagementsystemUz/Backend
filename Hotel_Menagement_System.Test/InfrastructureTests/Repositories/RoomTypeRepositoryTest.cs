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
        };
        await _typeRepository.AddAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Act
        await _typeRepository.UpdateAsync(roomType);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedRoomType = await _typeRepository.GetByIdAsync(roomType.Id);
        Assert.That(updatedRoomType.Name, Is.EqualTo("Test"));
    }





}
