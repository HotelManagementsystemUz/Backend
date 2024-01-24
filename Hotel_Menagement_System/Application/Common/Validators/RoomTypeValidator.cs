namespace Application.Common.Validators;

public static class RoomTypeValidator
{
    public static bool IsValid(this RoomType value)
        => value != null &&
           string.IsNullOrEmpty(value.Name) &&
           value.PersonCount > 0;

    public static bool IsExist(this RoomType value, IEnumerable<RoomType> roomTypes)
        => roomTypes.Any( i  => i.Name == value.Name &&
                          i.PersonCount == value.PersonCount && 
                          i.Id != value.Id);  
       

}
