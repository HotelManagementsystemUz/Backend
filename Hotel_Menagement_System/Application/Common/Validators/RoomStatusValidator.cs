

namespace Application.Common.Validators;

public static class RoomStatusValidator
{
    public static bool IsValid(this RoomStatus roomStatus)
        => roomStatus != null &&
        string.IsNullOrEmpty(roomStatus.Name);

    public static bool IsExist(this RoomStatus roomStatus, IEnumerable<RoomStatus> roomStatuses)
        => roomStatuses.Any(i =>  i.Name == roomStatus.Name && i.Id!=roomStatus.Id);
}
