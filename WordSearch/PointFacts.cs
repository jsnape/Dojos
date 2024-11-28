using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WordSearch;
public class PointFacts
{
    [Fact]
    public void CanMoveNorth()
    {
        var point = (3, 3);
        var newPoint = point.Move(Direction.North);
        Assert.Equal((3, 2), newPoint);
    }
}
