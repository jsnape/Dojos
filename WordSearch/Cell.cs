namespace WordSearch;

public record Cell(int X, int Y)
{
    public static Cell operator+(Cell c, Vector v) => new(c.X + v.DX, c.Y + v.DY);

    public Direction DirectionTo(Cell other) => (X, Y) switch
    {
        _ when X == other.X && Y < other.Y => Direction.South,
        _ when X == other.X && Y > other.Y => Direction.North,
        _ when X < other.X && Y == other.Y => Direction.East,
        _ when X > other.X && Y == other.Y => Direction.West,

        _ when X < other.X && Y < other.Y => Direction.SouthEast,
        _ when X < other.X && Y > other.Y => Direction.NorthEast,
        _ when X > other.X && Y < other.Y => Direction.SouthWest,
        _ when X > other.X && Y > other.Y => Direction.NorthWest,

        _ => throw new ArgumentOutOfRangeException(nameof(other)),
    };

    public Vector DistanceTo(Cell other) => new(other.X - X, other.Y - Y);

    public Cell Move(Direction direction) => this + Vector.Offset(direction);
}
