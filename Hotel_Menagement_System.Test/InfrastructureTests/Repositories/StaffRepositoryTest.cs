using Domain.Entities.HotelEntiries;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class StaffRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> options =
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("StaffDb")
            .Options;

    private ApplicationDbContext _dbContext;
    private StaffRepository _staffRepository;

    [SetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(options);
        _dbContext.Database.EnsureCreated();
        _staffRepository = new StaffRepository(_dbContext);
    }

    [Test]
    public async Task Test1_AddNewStaff()
    {
        // Arrange
        var staff = new Staff
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "johndoe",
            Email = "johndoe@example.com",
            PositionId = 1, 
            PhoneNumber = "1234567890",
            Gender = Gender.Male,
            BirthDate = new DateTime(1990, 1, 1),
            Address = "123 Main St, City, Country",
            Description = "Test Description"
        };

        // Act
        await _staffRepository.AddAsync(staff);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Staffs.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_GetStaffById()
    {
        // Arrange
        var staff = new Staff
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "johndoe",
            Email = "johndoe@example.com",
            PositionId = 1,
            PhoneNumber = "1234567890",
            Gender = Gender.Male,
            BirthDate = new DateTime(1990, 1, 1),
            Address = "123 Main St, City, Country",
            Description = "Test Description"
        };
        await _staffRepository.AddAsync(staff);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedStaff = await _staffRepository.GetByIdAsync(staff.Id);

        // Assert
        Assert.That(staff.FirstName, Is.EqualTo( retrievedStaff.FirstName));
        Assert.That(staff.LastName, Is.EqualTo(retrievedStaff.LastName));
    }

    [Test]
    public async Task Test3_DeleteStaff()
    {
        // Arrange
        var staff = new Staff
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "johndoe",
            Email = "johndoe@example.com",
            PositionId = 1, 
            PhoneNumber = "1234567890",
            Gender = Gender.Male,
            BirthDate = new DateTime(1990, 1, 1),
            Address = "123 Main St, City, Country",
            Description = "Test Description"
        };
        await _staffRepository.AddAsync(staff);
        await _dbContext.SaveChangesAsync();

        // Act
        await _staffRepository.DeleteAsync(staff.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Staffs.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test3_UpdateStaff()
    {
        // Arrange
        var staff = new Staff
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "johndoe",
            Email = "johndoe@example.com",
            PositionId = 1,
            PhoneNumber = "1234567890",
            Gender = Gender.Male,
            BirthDate = new DateTime(1990, 1, 1),
            Address = "123 Main St, City, Country",
            Description = "Test Description"
        };
        await _staffRepository.AddAsync(staff);
        await _dbContext.SaveChangesAsync();

        // Act
        staff.FirstName = "UpdatedJohn";
        await _staffRepository.UpdateAsync(staff);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedStaff = await _staffRepository.GetByIdAsync(staff.Id);
        Assert.That(staff.FirstName, Is.EqualTo( updatedStaff.FirstName));
    }

    [Test]
    public async Task Test4_GetAllStaff()
    {
        // Arrange
        var staff1 = new Staff
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "johndoe",
            Email = "johndoe@example.com",
            PositionId = 1,
            PhoneNumber = "1234567890",
            Gender = Gender.Male,
            BirthDate = new DateTime(1990, 1, 1),
            Address = "123 Main St, City, Country",
            Description = "Test Description"
        };

        var staff2 = new Staff
        {
            FirstName = "Jane",
            LastName = "Doe",
            FatherName = "Alex",
            Username = "janedoe",
            Email = "janedoe@example.com",
            PositionId = 2,
            PhoneNumber = "9876543210",
            Gender = Gender.Female,
            BirthDate = new DateTime(1995, 2, 15),
            Address = "456 Second St, City, Country",
            Description = "Test Description for Jane"
        };

        await _staffRepository.AddAsync(staff1);
        await _staffRepository.AddAsync(staff2);
        await _dbContext.SaveChangesAsync();

        // Act
        var allStaff = await _staffRepository.GetAllAsync();

        // Assert
        Assert.That(allStaff.Count(), Is.EqualTo(2));

    }
}