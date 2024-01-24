namespace Application.Common.Validators;

public static class PositionValidator
{
    public static bool IsValid(this Position position)
    => position != null &&
    string.IsNullOrEmpty(position.Name);

    public static bool IsExist(this Position position, IEnumerable<Position> positions)
        => positions.Any(i => i.Name == position.Name && i.Id != position.Id);
}
