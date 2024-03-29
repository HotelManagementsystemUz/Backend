﻿

using Domain.Entities.HotelEntiries;

namespace Infrastructure.Interfaces;

public interface IOrderInterface:IRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrdersWithStatusAsync();
}
