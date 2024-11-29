using Xunit;

namespace WordSearch.Tests;

public class CellFacts
{
    [Theory]
    [InlineData(1, 1, 1, 0, Direction.North)]
    [InlineData(1, 1, 1, 2, Direction.South)]
    [InlineData(1, 1, 2, 1, Direction.East)]
    [InlineData(1, 1, 0, 1, Direction.West)]
    [InlineData(1, 1, 2, 0, Direction.NorthEast)]
    [InlineData(1, 1, 0, 0, Direction.NorthWest)]
    [InlineData(1, 1, 2, 2, Direction.SouthEast)]
    [InlineData(1, 1, 0, 2, Direction.SouthWest)]
    public void DirectionTo(int x1, int y1, int x2, int y2, Direction expectedDirection)
    {
        var cell = new Cell(x1, y1);
        var other = new Cell(x2, y2);

        Assert.Equal(expectedDirection, cell.DirectionTo(other));
    }

    [Theory]
    [InlineData(1, 1, 3, 3, 2, 2)]
    [InlineData(1, 1, 4, 3, 3, 2)]
    [InlineData(4, 3, 1, 1, -3, -2)]
    public void DistanceTo(int x1, int y1, int x2, int y2, int dx, int dy)
    {
        var cell = new Cell(x1, y1);
        var other = new Cell(x2, y2);

        var distance = cell.DistanceTo(other);

        Assert.Equal(dx, distance.DX);
        Assert.Equal(dy, distance.DY);
    }
}
