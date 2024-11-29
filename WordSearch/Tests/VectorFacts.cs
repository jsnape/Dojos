using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace WordSearch.Tests;

public class VectorFacts
{
    [Fact]
    public void IsZero()
    {
        var vector = new Vector(0, 0);
        Assert.True(vector.IsZero);
    }

    [Property]
    public Property IsNotZero(int x, int y)
    {
        var vector = new Vector(x, y);
        return (x != 0 || y != 0).Implies(vector.IsZero == false);
    }

    [Property]
    public Property LengthIsPositive(int x, int y)
    {
        var vector = new Vector(x, y);
        return (x != 0 || y != 0).Implies(vector.Length >= 0);
    }

    [Property]
    public Property LengthIsCorrect(int x, int y)
    {
        var vector = new Vector(x, y);
        return (vector.Length == Math.Max(Math.Abs(x), Math.Abs(y))).ToProperty();
    }

    [Property]
    public Property DirectionIsCorrect(int x, int y)
    {
        var vector = new Vector(x, y);
        return (vector.Direction == (x, y) switch
        {
            (0, 0) => Direction.None,

            (0, _) when y < 0 => Direction.North,
            (0, _) when y > 0 => Direction.South,
            (_, 0) when x < 0 => Direction.West,
            (_, 0) when x > 0 => Direction.East,

            (_, _) when x > 0 && y < 0 => Direction.NorthEast,
            (_, _) when x > 0 && y > 0 => Direction.SouthEast,
            (_, _) when x < 0 && y > 0 => Direction.SouthWest,
            (_, _) when x < 0 && y < 0 => Direction.NorthWest,

            _ => throw new ArgumentOutOfRangeException(nameof(Vector)),
        })
        .Classify(x == 0 && y == 0, "Zero vector")
        .Classify(x == 0 && y != 0, "Vertical vector")
        .Classify(x != 0 && y == 0, "Horizontal vector")
        .Classify(x != 0 && y != 0, "Diagonal vector");
    }

    [Property]
    public Property OffSetIsCorrect(Direction direction)
    {
        var vector = Vector.Offset(direction);
        return (vector.Direction == direction).ToProperty();
    }
}
