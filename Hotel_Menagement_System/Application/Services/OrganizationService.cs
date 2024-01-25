using Application.DTOs.HotelDtos.Organization;

namespace Application.Services;

public class OrganizationService(IMapper mapper, IUnitOfWork unitOfWork) : IOrganizationService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public async Task AddAsync(AddOrganizationDto dto)
    {
        if(dto == null)
        {
            throw new   ArgumentNullException("Organization is null ");
        }
        var organization = _mapper.Map<Organization>(dto);
        if(organization == null)
        {
            throw new CustomException("Organization does not Mapped");
        }
        if (organization.IsValid())
        {
            throw new CustomException("Organization is invalid");
        }
        var organizations = await _unitOfWork.OrganizitionInterface.GetAllAsync();
        if(organizations == null)
        {
            throw new NotFoundException("Organization is not found");
        }
        if(organization.IsExist(organizations))
        {
            throw new CustomException("Organization is already exist");
        }
 

        await _unitOfWork.OrganizitionInterface.AddAsync(organization);
        await _unitOfWork.SaveChangeAsync();
        

    }

    public async Task DeleteAsync(int id)
    {
        if(id < 0)
        {
            throw new ArgumentException("Id 0 dan katta bo'lishi kerak");
        }
        var organization = await _unitOfWork.OrganizitionInterface.GetByIdAsync(id);
        if(organization == null)
        {
            throw new NotFoundException("Bunday id raqamli Organization mavjud emas ");
        }
        await _unitOfWork.OrganizitionInterface.DeleteAsync(id);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<OrganizationDto>> GetAllAsync()
    {
        var organizations = await _unitOfWork.OrganizitionInterface.GetAllAsync();
        if (organizations == null)
        {
            throw new NotFoundException("Organization is not found");
        }
        return organizations.Select(o => _mapper.Map<OrganizationDto>(o)).ToList();
    }

    public async Task<List<OrganizationDto>> Filter(string text)
    {
        var organizations = await _unitOfWork.OrganizitionInterface.GetAllAsync();
        var filteredOrganizations = organizations.Where(o =>
            o.OrganizationName.Contains(text) ||
            o.PhoneNumber.Contains(text) ||
            o.Inn.Contains(text) ||
            o.DerektorFullName.Contains(text) ||
            o.YuridikAddress.Contains(text) ||
            o.OtherInformation.Contains(text)
        ).ToList();

        var result = filteredOrganizations.Select(o => _mapper.Map<OrganizationDto>(o)).ToList();
        return result;
    }


    public async Task<OrganizationDto> GetByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id 0 dan katta bo'lishi kerak");
        }
        var organization = await _unitOfWork.OrganizitionInterface.GetByIdAsync(id);
        if (organization == null)
        {
            throw new NotFoundException("Bunday id raqamli Organization mavjud emas ");
        }
        return _mapper.Map<OrganizationDto>(organization);
    }

    public async Task UpdateAsync(UpdateOrganizationDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException("Organization is null ");
        }
        var organization = _mapper.Map<Organization>(dto);
        if (organization == null)
        {
            throw new CustomException("Organization does not Mapped");
        }
        if (organization.IsValid())
        {
            throw new CustomException("Organization is invalid");
        }
        var organizations = await _unitOfWork.OrganizitionInterface.GetAllAsync();
        if (organizations == null)
        {
            throw new NotFoundException("Organization is not found");
        }

        await _unitOfWork.OrganizitionInterface.UpdateAsync(organization);
        await _unitOfWork.SaveChangeAsync();
    }
}
