using Domain.Entities.HotelEntiries;

namespace Application.Common.Validators;

public static class GuestValidator
{
    public static bool IsValidGuest(this Guest guest)
        => guest != null &&
        string.IsNullOrEmpty(guest.FirstName) &&
        string.IsNullOrEmpty(guest.LastName) &&
        string.IsNullOrEmpty(guest.PhoneNumber) &&
        string.IsNullOrEmpty(guest.FatherName) &&
        string.IsNullOrEmpty(guest.Address) &&
        string.IsNullOrEmpty(guest.CITIZENSHIP) &&
        string.IsNullOrEmpty(guest.Description) &&
        string.IsNullOrEmpty(guest.GIVENBYWHOM) &&
        string.IsNullOrEmpty(guest.Organization) &&
        string.IsNullOrEmpty(guest.OrganizationName);

    public static bool IsExistGuest(this Guest guest, IEnumerable<Guest> guests)
        => guests.Any(g => g.FirstName == guest.FirstName &&
                      g.LastName == guest.LastName &&   
                      g.PhoneNumber == guest.PhoneNumber &&
                      g.Address == guest.Address &&
                      g.BirthDate == guest.BirthDate &&
                      g.Description == guest.Description &&
                      g.CITIZENSHIP == guest.CITIZENSHIP &&
                      g.FatherName == guest.FatherName &&
                      g.Gender == guest.Gender &&
                      g.Organization == guest.Organization &&
                      g.OrganizationName == guest.OrganizationName &&
                      g.Id != guest.Id
        );


           

}
