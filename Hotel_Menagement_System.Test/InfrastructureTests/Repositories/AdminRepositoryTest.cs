//using Infrastructure.Data;
//using Infrastructure.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Domain.Entities.HotelEntiries;

//namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

//public class AdminRepositoryTest
//{
//    private DbContextOptions<ApplicationDbContext> options =
//        new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase("AdminDb")
//            .Options;

//    private ApplicationDbContext _dbContext;
//    private AdminRepository _adminRepository;

//    [SetUp]
//    public void Setup()
//    {
//        _dbContext = new ApplicationDbContext(options);
//        _dbContext.Database.EnsureCreated();
//        _adminRepository = new AdminRepository(_dbContext);
//    }

//    [Test]
//    public async Task Test1_AddNewAdmin()
//    {
//        // Arrange
//        var admin = new Admin
//        {
//            FirstName = "John",
//            LastName = "Doe",
//            Email = "john@example.com",
//            PhoneNumber = "123456789",
//            Address = "123 Main Street"
//        };

//        // Act
//        await _adminRepository.AddAsync(admin);
//        await _dbContext.SaveChangesAsync();

//        // Assert
//        Assert.That(_dbContext.Admins.Count(), Is.EqualTo(1));
//    }

//    [Test]
//    public async Task Test2_GetAdminById()
//    {
//        // Arrange
//        var admin = new Admin
//        {
//            FirstName = "Jane",
//            LastName = "Doe",
//            Email = "jane@example.com",
//            PhoneNumber = "987654321",
//            Address = "456 Elm Street"
//        };
//        await _adminRepository.AddAsync(admin);
//        await _dbContext.SaveChangesAsync();

//        // Act
//        var retrievedAdmin = await _adminRepository.GetByIdAsync(admin.Id);

//        // Assert
//        Assert.That(admin.FirstName, Is.EqualTo("Jane"));
//    }

//    [Test]
//    public async Task Test3_GetAllAdmins()
//    {
//        // Arrange
//        await _adminRepository.AddAsync(new Admin
//        {
//            FirstName = "Admin1",
//            LastName = "One",
//            Email = "admin1@example.com",
//            PhoneNumber = "111111111",
//            Address = "Address 1"
//        });

//        await _adminRepository.AddAsync(new Admin
//        {
//            FirstName = "Admin2",
//            LastName = "Two",
//            Email = "admin2@example.com",
//            PhoneNumber = "222222222",
//            Address = "Address 2"
//        });

//        await _dbContext.SaveChangesAsync();

//        // Act
//        var admins = await _adminRepository.GetAllAsync();

//        // Assert
//        Assert.That( admins.Count , Is.EqualTo(2));
//    }

//    [Test]
//    public async Task Test4_UpdateAdmin()
//    {
//        // Arrange
//        var admin = new Admin
//        {
//            FirstName = "OriginalFirstName",
//            LastName = "OriginalLastName",
//            Email = "original@example.com",
//            PhoneNumber = "123456789",
//            Address = "Original Address"
//        };
//        await _adminRepository.AddAsync(admin);
//        await _dbContext.SaveChangesAsync();

//        // Act
//        admin.FirstName = "UpdatedFirstName";
//        await _adminRepository.UpdateAsync(admin);
//        await _dbContext.SaveChangesAsync();

//        // Assert
//        var updatedAdmin = await _adminRepository.GetByIdAsync(admin.Id);
//        Assert.That(updatedAdmin.FirstName, Is.EqualTo("UpdatedFirstName"));
//    }

//    [Test]
//    public async Task Test5_DeleteAdmin()
//    {
//        // Arrange
//        var admin = new Admin
//        {
//            FirstName = "To Be Deleted",
//            LastName = "Doe",
//            Email = "delete@example.com",
//            PhoneNumber = "123456789",
//            Address = "123 Main Street"
//        };
//        await _adminRepository.AddAsync(admin);
//        await _dbContext.SaveChangesAsync();

//        // Act
//        await _adminRepository.DeleteAsync(admin.Id);
//        await _dbContext.SaveChangesAsync();

//        // Assert
//        var deletedAdmin = await _adminRepository.GetByIdAsync(admin.Id);
//        Assert.That(deletedAdmin, Is.EqualTo(null));
//    }
//}
