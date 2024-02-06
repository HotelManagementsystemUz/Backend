using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class PositionRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> options =
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("PositionDb")
            .Options;

    private ApplicationDbContext _dbContext;
    private PositionRepository _positionRepository;

    [SetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        _positionRepository = new PositionRepository(_dbContext);
    }

    [Test]
    public async Task Test1_AddNewPosition()
    {
        // Arrange
        var position = new Position
        {
            Name = "Test Position"
        };

        // Act
        await _positionRepository.AddAsync(position);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Positions.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_UpdatePosition()
    {
        // Arrange
        var position = new Position
        {
            Name = "Test Position"
        };
        await _positionRepository.AddAsync(position);
        await _dbContext.SaveChangesAsync();

        // Act
        position.Name = "Updated Position";
        await _positionRepository.UpdateAsync(position);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedPosition = await _dbContext.Positions.FindAsync(position.Id);
        Assert.That(updatedPosition.Name, Is.EqualTo("Updated Position"));
    }

    [Test]
    public async Task Test3_DeletePosition()
    {
        // Arrange
        var position = new Position
        {
            Name = "Test Position"
        };
        await _positionRepository.AddAsync(position);
        await _dbContext.SaveChangesAsync();

        // Act
        await _positionRepository.DeleteAsync(position.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Positions.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_GetPositionById()
    {
        // Arrange
        var position = new Position
        {
            Name = "Test Position"
        };
        await _positionRepository.AddAsync(position);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedPosition = await _positionRepository.GetByIdAsync(position.Id);

        // Assert
        Assert.That(retrievedPosition.Id, Is.EqualTo(position.Id));
    }

    [Test]
    public async Task Test5_GetAllPositions()
    {
        // Arrange
        var position1 = new Position { Name = "Position 1" };
        var position2 = new Position { Name = "Position 2" };
        await _positionRepository.AddAsync(position1);
        await _positionRepository.AddAsync(position2);
        await _dbContext.SaveChangesAsync();

        // Act
        var positions = await _positionRepository.GetAllAsync();

        // Assert
        Assert.That(positions.Count, Is.EqualTo(2));
    }
}
