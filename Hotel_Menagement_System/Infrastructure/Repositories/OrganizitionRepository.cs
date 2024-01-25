using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class OrganizitionRepository : Repository<Organization>, IOrganizitionInterface
{
    public OrganizitionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
