using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Test.InfrastructureTests.Repositories;

[TestFixture]
public class OrganizationRepositoryTest
{
    private DbContextOptions<ApplicationDbContext> _options;
    private ApplicationDbContext _dbContext;
    private OrganizitionRepository _organizationRepository;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("OrganizationDb")
            .Options;

        _dbContext = new ApplicationDbContext(_options);
        _organizationRepository = new OrganizitionRepository(_dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task Test1_AddNewOrganization()
    {
        // Arrange
        var organization = new Organization
        {
            OrganizationName = "Test Organization",
            PhoneNumber = "1234567890",
            Inn = "123456789012",
            DerektorFullName = "John Doe",
            YuridikAddress = "123 Main St, City, Country",
            OtherInformation = "Test information"
        };

        // Act
        await _organizationRepository.AddAsync(organization);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Organizations.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task Test2_GetOrganizationById()
    {
        // Arrange
        var organization = new Organization
        {
            OrganizationName = "Test Organization",
            PhoneNumber = "1234567890",
            Inn = "123456789012",
            DerektorFullName = "John Doe",
            YuridikAddress = "123 Main St, City, Country",
            OtherInformation = "Test information"
        };
        await _organizationRepository.AddAsync(organization);
        await _dbContext.SaveChangesAsync();

        // Act
        var retrievedOrganization = await _organizationRepository.GetByIdAsync(organization.Id);

        // Assert
        Assert.That(organization.OrganizationName, Is.EqualTo(retrievedOrganization.OrganizationName));
        Assert.That(organization.PhoneNumber, Is.EqualTo(retrievedOrganization.PhoneNumber));
    }

    [Test]
    public async Task Test3_DeleteOrganization()
    {
        // Arrange
        var organization = new Organization
        {
            OrganizationName = "Test Organization",
            PhoneNumber = "1234567890",
            Inn = "123456789012",
            DerektorFullName = "John Doe",
            YuridikAddress = "123 Main St, City, Country",
            OtherInformation = "Test information"
        };
        await _organizationRepository.AddAsync(organization);
        await _dbContext.SaveChangesAsync();

        // Act
        await _organizationRepository.DeleteAsync(organization.Id);
        await _dbContext.SaveChangesAsync();

        // Assert
        Assert.That(_dbContext.Organizations.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task Test4_UpdateOrganization()
    {
        // Arrange
        var organization = new Organization
        {
            OrganizationName = "Test Organization",
            PhoneNumber = "1234567890",
            Inn = "123456789012",
            DerektorFullName = "John Doe",
            YuridikAddress = "123 Main St, City, Country",
            OtherInformation = "Test information"
        };
        await _organizationRepository.AddAsync(organization);
        await _dbContext.SaveChangesAsync();

        // Act
        organization.OrganizationName = "Updated Organization";
        await _organizationRepository.UpdateAsync(organization);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedOrganization = await _organizationRepository.GetByIdAsync(organization.Id);
        Assert.That(organization.OrganizationName, Is.EqualTo(updatedOrganization.OrganizationName));
    }

    [Test]
    public async Task Test5_GetAllOrganizations()
    {
        // Arrange
        var organization1 = new Organization
        {
            OrganizationName = "Test Organization 1",
            PhoneNumber = "1234567890",
            Inn = "123456789012",
            DerektorFullName = "John Doe",
            YuridikAddress = "123 Main St, City, Country",
            OtherInformation = "Test information 1"
        };

        var organization2 = new Organization
        {
            OrganizationName = "Test Organization 2",
            PhoneNumber = "9876543210",
            Inn = "987654321012",
            DerektorFullName = "Jane Doe",
            YuridikAddress = "456 Second St, City, Country",
            OtherInformation = "Test information 2"
        };

        await _organizationRepository.AddAsync(organization1);
        await _organizationRepository.AddAsync(organization2);
        await _dbContext.SaveChangesAsync();

        // Act
        var allOrganizations = await _organizationRepository.GetAllAsync();

        // Assert
        Assert.That(allOrganizations.Count(), Is.EqualTo(2));
    }
}
