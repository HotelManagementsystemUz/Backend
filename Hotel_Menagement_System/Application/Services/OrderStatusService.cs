using Application.DTOs.HotelDtos.OrderStatus;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class OrderStatusService(IMapper mapper, IUnitOfWork unitOfWork) : IOrderStatusService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddOrderStatusAsync(AddOrderStatusDto dto)
    {
        if (dto == null) throw new ArgumentNullException("OrderStatus is null");
        var orderStatus = _mapper.Map<OrderStatus>(dto);
        if(orderStatus == null)
        {
            throw new CustomException("Orderstatus does not Mapped ");
        }

        if (orderStatus.IsValid())
        {
            throw new CustomException("OrderStatus is invalid");
        }
        var orderstatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orderstatuses == null)
        {
            throw new NotFoundException("OrderStatus does not found");
        }
        if(orderStatus.IsExist(orderstatuses))
        {
            throw new CustomException("OrderStatus is already exist");
        }
        await _unitOfWork.OrderStatusInterface.AddAsync(orderStatus);
        await _unitOfWork.SaveChangeAsync();

    }

    public async Task DeleteOrderStatusAsync(int id)
    {
        if(id < 0)
        {
            throw new CustomException("Id 0 dan katta bo'lish kerak");
        }
        var orderstatus = await _unitOfWork.OrderStatusInterface.GetByIdAsync(id);
        if (orderstatus == null)
        {
            throw new NotFoundException("Bunday Id raqamli OrderStatus mavjud emas ");
        }
        await _unitOfWork.OrderStatusInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<OrderStatusDto>> GetAllOrderStatusAsync()
    {
        var orderStatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if(orderStatuses == null)
        {
            throw new NotFoundException("Hech qanday orderstatus topilmadi");
        }
        return await orderStatuses.Select(status => _mapper.Map<OrderStatusDto>(status)).ToListAsync();
    }

    public async Task<OrderStatusDto> GetByIdOrderStatusAsync(int id)
    {
        if (id < 0)
        {
            throw new CustomException("Id 0 dan katta bo'lish kerak");
        }
        var orderstatus = await _unitOfWork.OrderStatusInterface.GetByIdAsync(id);
        if (orderstatus == null)
        {
            throw new NotFoundException("Bunday Id raqamli OrderStatus mavjud emas ");
        }
        return _mapper.Map<OrderStatusDto>(orderstatus);
    }

    public async Task UpdateOrderStatusAsync(UpdateOrderStatusDto dto)
    {

        if (dto == null) throw new ArgumentNullException("OrderStatus is null");
        var orderStatus1 = await _unitOfWork.OrderStatusInterface.GetByIdAsync(dto.Id);
        if(orderStatus1  == null)
        {
            throw new CustomException("Bunday Id raqamli OrderStatus mavjud emas");
        }
        var orderStatus = _mapper.Map<OrderStatus>(dto);
        if (orderStatus == null)
        {
            throw new CustomException("Orderstatus does not Mapped ");
        }

        if (orderStatus.IsValid())
        {
            throw new CustomException("OrderStatus is invalid");
        }
        var orderstatuses = await _unitOfWork.OrderStatusInterface.GetAllAsync();
        if (orderstatuses == null)
        {
            throw new NotFoundException("OrderStatus does not found");
        }

        await _unitOfWork.OrderStatusInterface.UpdateAsync(orderStatus);
        await _unitOfWork.SaveChangeAsync();
    }
}
