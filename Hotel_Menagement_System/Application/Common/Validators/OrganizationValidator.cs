namespace Application.Common.Validators;

public static class OrganizationValidator
{
    public static bool IsValid(this Organization organization)
        => organization != null &&
        string.IsNullOrEmpty(organization.OrganizationName) &&
        string.IsNullOrEmpty(organization.PhoneNumber) &&
        string.IsNullOrEmpty(organization.Inn) &&
        string.IsNullOrEmpty(organization.DerektorFullName) &&
        string.IsNullOrEmpty(organization.YuridikAddress) &&
        string.IsNullOrEmpty(organization.OtherInformation);

    public static bool IsExist(this Organization organization, IEnumerable<Organization> organizations)
        => organizations.Any(o => o.OrganizationName == organization.OrganizationName &&
                                  o.PhoneNumber == organization.PhoneNumber &&
                                  o.Inn == organization.Inn &&
                                  o.DerektorFullName == organization.DerektorFullName &&
                                  o.YuridikAddress == organization.YuridikAddress &&
                                  o.OtherInformation == organization.OtherInformation &&
                                  o.Id != organization.Id
        );
        
}
