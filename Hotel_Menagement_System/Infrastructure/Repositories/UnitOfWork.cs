using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext dbContext,
                        IAdminInterface adminInterface,
                        IGuestInterface guestInterface,
                        IOrderInterface orderInterface, 
                        IOrderStatusInterface orderStatusInterface,
                        IPositionInterface positionInterface,
                        IRoomInterface roomInterface, 
                        IRoomStatusInterface roomStatusInterface,
                        IRoomTypeInterface roomTypeInterface,
                        IStaffInterface staffInterface,
                        IOrganizitionInterface organizitionInterface) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IAdminInterface AdminInterface { get; } = adminInterface;

    public IGuestInterface GuestInterface { get; } = guestInterface;

    public IOrderInterface OrderInterface { get; } = orderInterface;

    public IOrderStatusInterface OrderStatusInterface { get; } = orderStatusInterface;

    public IPositionInterface PositionInterface { get; } = positionInterface;

    public IRoomInterface RoomInterface { get; } = roomInterface;

    public IRoomStatusInterface RoomStatusInterface { get; } = roomStatusInterface;

    public IRoomTypeInterface RoomTypeInterface { get; } = roomTypeInterface;

    public IStaffInterface StaffInterface { get; } = staffInterface;

    public IOrganizitionInterface OrganizitionInterface { get; } = organizitionInterface;

    public void Dispose()
         => GC.SuppressFinalize(this);

    public async Task SaveChangeAsync()
        => await _dbContext.SaveChangesAsync();
}
