namespace Application.Common.Validators;
public static class StaffValidator
{
    public static bool IsValid(this Staff staff)
        => staff != null &&
        string.IsNullOrEmpty(staff.FirstName) &&
        string.IsNullOrEmpty(staff.LastName) &&
        string.IsNullOrEmpty(staff.Email) &&
        string.IsNullOrEmpty(staff.Address) &&
        string.IsNullOrEmpty(staff.PhoneNumber) &&
        string.IsNullOrEmpty(staff.Username) &&
        staff.PositionId > 0 &&
        staff.BirthDate > DateTime.Now;


    public static bool IsExist(this Staff staff, IEnumerable<Staff> staffs)
        => staffs.Any(s => s.FirstName == staff.FirstName &&
                      s.LastName == staff.LastName && 
                      s.Email == staff.Email &&
                      s.PhoneNumber == staff.PhoneNumber && 
                      s.PositionId == staff.PositionId &&
                      s.Address ==staff.Address &&
                      s.BirthDate == staff.BirthDate &&
                      s.Username == staff.Username  &&
                      s.Id != staff.Id
        );

}
