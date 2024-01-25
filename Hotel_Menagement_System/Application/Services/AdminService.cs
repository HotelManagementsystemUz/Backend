using Application.DTOs.HotelDtos.Admin;

namespace Application.Services;

public class AdminService(IMapper mapper, IUnitOfWork unitOfWork) : IAdminService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddAdminAsync(AddAdminDto dto)
    {
        if(dto == null)
        {
            throw new ArgumentNullException("Admin is null");
        }
        var admin = _mapper.Map<Admin>(dto);    
        if(admin == null)
        {
            throw new CustomException("Admin did not mapped");
        }
        var admins = await _unitOfWork.AdminInterface.GetAllAsync();
        if(admins == null)
        {
            throw new NotFoundException("Hech qanday admin topilmadi ");
        }
        if (!admin.IsValid())
        {
            throw new CustomException("Admin is invalid");
        }
        if (!admin.IsExist(admins))
        {
            throw new CustomException("Admin is already exsit");
        }
        await _unitOfWork.AdminInterface.AddAsync(admin);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAdminAsync(int id)
    {
        if (id <= 0)
        {
            throw new CustomException("Id should be greater than 0");
        }

        var admin = await _unitOfWork.AdminInterface.GetByIdAsync(id);

        if (admin is null)
        {
            throw new ArgumentNullException("Admin not found");
        }

        await _unitOfWork.AdminInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<AdminDto>> GetAllAdminsAsync()
    {
        var Admins = await _unitOfWork.AdminInterface.GetAllAsync();
        if(Admins is null)
        {
            throw new NotFoundException("Hech qanday admin topilmadi");
        }
        return Admins.Select(x => _mapper.Map<AdminDto>(x)).ToList();
    }

    public async Task<AdminDto> GetByIdAdminAsync(int id)
    {
        if (id <= 0)
        {
            throw new CustomException("Id should be greater than 0");
        }

        var admin = await _unitOfWork.AdminInterface.GetByIdAsync(id);

        if (admin is null)
        {
            throw new ArgumentNullException("Admin not found");
        }
        return _mapper.Map<AdminDto>(admin);
    }

    public async Task UpdateAdminAsync(UpdateAdminDto dto)
    {

        if (dto == null)
        {
            throw new ArgumentNullException("Admin is null");
        }
        var admin = _mapper.Map<Admin>(dto);
        if (admin == null)
        {
            throw new CustomException("Admin did not mapped");
        }
        var admins = await _unitOfWork.AdminInterface.GetAllAsync();
        if (admins == null)
        {
            throw new NotFoundException("Hech qanday admin topilmadi ");
        }
        if (!admin.IsValid())
        {
            throw new CustomException("Admin is invalid");
        }
        if (!admin.IsExist(admins))
        {
            throw new CustomException("Admin is already exsit");
        }
        await _unitOfWork.AdminInterface.UpdateAsync(admin);
        await _unitOfWork.SaveChangeAsync();
    }
}
