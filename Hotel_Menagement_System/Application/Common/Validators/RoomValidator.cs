namespace Application.Common.Validators;

public static class RoomValidator
{
    public static bool IsValid(this Room room)
        => room != null &&
        string.IsNullOrEmpty(room.Description) &&
        room.Number > 0 &&
        room.RoomStatusId > 0 &&
        room.RoomTypeId > 0;
    public static bool IsExist(this Room room, IEnumerable<Room> rooms)
        => rooms.Any(r => r.Id != room.Id &&
                     r.Description == room.Description &&
                     r.Number == room.Number &&
                     r.RoomStatusId == room.RoomStatusId &&
                     r.RoomTypeId == room.RoomTypeId);
}
