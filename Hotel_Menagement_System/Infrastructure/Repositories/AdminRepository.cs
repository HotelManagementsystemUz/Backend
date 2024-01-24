using Domain.Entities.HotelEntiries;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AdminRepository : Repository<Admin>, IAdminInterface
{
    public AdminRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
