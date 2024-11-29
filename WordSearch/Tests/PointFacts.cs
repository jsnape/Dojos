using Xunit;

namespace WordSearch.Tests;

public class PointFacts
{
    [Fact]
    public void CanMoveNorth()
    {
        var point = (3, 3);
        var newPoint = point.Move(Direction.North);
        Assert.Equal((3, 2), newPoint);
    }

    [Fact]
    public void CanMoveWest()
    {
        var point = (3, 3);
        var newPoint = point.Move(Direction.West);
        Assert.Equal((2, 3), newPoint);
    }

    [Fact]
    public void CanMoveSoutEast()
    {
        var startPoint = (3, 3);

        var indirect = startPoint
            .Move(Direction.East)
            .Move(Direction.South);

        var direct = startPoint.Move(Direction.SouthEast);

        Assert.Equal(indirect, direct);
        Assert.Equal((4, 4), direct);
    }
}
