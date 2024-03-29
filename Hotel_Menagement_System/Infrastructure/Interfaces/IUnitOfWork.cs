﻿

namespace Infrastructure.Interfaces;

public interface IUnitOfWork:IDisposable
{

    IGuestInterface GuestInterface { get; }

    IOrderInterface OrderInterface { get; }

    IOrderStatusInterface OrderStatusInterface { get; }

    IPositionInterface PositionInterface { get; }

    IRoomInterface RoomInterface { get; }

    IRoomStatusInterface RoomStatusInterface { get; }

    IRoomTypeInterface RoomTypeInterface { get; }

    IStaffInterface StaffInterface { get; }
    IOrganizitionInterface OrganizitionInterface { get; }


    Task SaveChangeAsync();
}
