using Domain.Entities.HotelEntiries;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class GuestRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> _options;
    private ApplicationDbContext _dbContext;
    private GuestRepository _guestRepository;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("GuestDb")
            .Options;

        _dbContext = new ApplicationDbContext(_options);
        _guestRepository = new GuestRepository(_dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task Test1_AddNewGuest()
    {
        // Arrange
        var guest = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "1234567890",
            Passport = "AB1234567",
            BirthDate = new DateTime(1990, 1, 1),
            DateOfIssue = DateTime.Now,
            Address = "123 Main St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Male
        };

        // Act
        await _guestRepository.AddAsync(guest);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Guests.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_GetGuestById()
    {
        // Arrange
        var guest = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "1234567890",
            Passport = "AB1234567",
            BirthDate = new DateTime(1990, 1, 1),
            DateOfIssue = DateTime.Now,
            Address = "123 Main St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Male
        };
        await _guestRepository.AddAsync(guest);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedGuest = await _guestRepository.GetByIdAsync(guest.Id);

        // Assert
        Assert.That(retrievedGuest.FirstName, Is.EqualTo(guest.FirstName));
        Assert.That(retrievedGuest.LastName, Is.EqualTo(guest.LastName));
    }

    [Test]
    public async Task Test3_DeleteGuest()
    {
        // Arrange
        var guest = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "1234567890",
            Passport = "AB1234567",
            BirthDate = new DateTime(1990, 1, 1),
            DateOfIssue = DateTime.Now,
            Address = "123 Main St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Male
        };
        await _guestRepository.AddAsync(guest);
        await _dbContext.SaveChangesAsync();

        // Act
        await _guestRepository.DeleteAsync(guest.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Guests.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_UpdateGuest()
    {
        // Arrange
        var guest = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "1234567890",
            Passport = "AB1234567",
            BirthDate = new DateTime(1990, 1, 1),
            DateOfIssue = DateTime.Now,
            Address = "123 Main St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Male
        };
        await _guestRepository.AddAsync(guest);
        await _dbContext.SaveChangesAsync();

        // Act
        guest.FirstName = "UpdatedJohn";
        await _guestRepository.UpdateAsync(guest);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedGuest = await _guestRepository.GetByIdAsync(guest.Id);
        Assert.That(updatedGuest.FirstName, Is.EqualTo("UpdatedJohn"));
    }

    [Test]
    public async Task Test5_GetAllGuests()
    {
        // Arrange
        var guest1 = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "1234567890",
            Passport = "AB1234567",
            BirthDate = new DateTime(1990, 1, 1),
            DateOfIssue = DateTime.Now,
            Address = "123 Main St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Male
        };

        var guest2 = new Guest
        {
            FirstName = "Jane",
            LastName = "Doe",
            FatherName = "Alex",
            PhoneNumber = "9876543210",
            Passport = "CD9876543",
            BirthDate = new DateTime(1995, 2, 15),
            DateOfIssue = DateTime.Now,
            Address = "456 Second St, City, Country",
            OrganizationName = "Test Organization",
            GIVENBYWHOM = "Test Authority",
            CITIZENSHIP = "Test Citizenship",
            Description = "Test Description",
            Organization = "Test Organization",
            Gender = Gender.Female
        };

        await _guestRepository.AddAsync(guest1);
        await _guestRepository.AddAsync(guest2);
        await _dbContext.SaveChangesAsync();

        // Act
        var allGuests = await _guestRepository.GetAllAsync();

        // Assert
        Assert.That(allGuests.Count(), Is.EqualTo(2));
    }
}
