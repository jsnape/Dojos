namespace WordSearch;

public enum Direction
{
    None,
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest,
    West,
    NorthWest,
}

public record Vector(int DX, int DY)
{
    public bool IsZero => DX == 0 && DY == 0;

    public int Length => Math.Max(Math.Abs(DX), Math.Abs(DY));

    public Direction Direction => (DX, DY) switch
    {
        (0, 0) => Direction.None,

        (0, _) when DY < 0 => Direction.North,
        (0, _) when DY > 0 => Direction.South,
        (_, 0) when DX < 0 => Direction.West,
        (_, 0) when DX > 0 => Direction.East,

        (_, _) when DX > 0 && DY < 0 => Direction.NorthEast,
        (_, _) when DX > 0 && DY > 0 => Direction.SouthEast,
        (_, _) when DX < 0 && DY > 0 => Direction.SouthWest,
        (_, _) when DX < 0 && DY < 0 => Direction.NorthWest,

        _ => throw new ArgumentOutOfRangeException(nameof(Vector)),
    };
}
