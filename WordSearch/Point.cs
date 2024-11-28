using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch;

public enum Direction
{
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest,
    West,
    NorthWest,
}

public static class PointExtensions
{
    public static (int x, int y) Move(this (int x, int y) point, Direction direction)
    {
        var (x, y) = Offset(direction);
        return (point.x + x, point.y + y);
    }

    public static (int x, int y) Offset(Direction direction) => direction switch
    { 
       Direction.North => (0, -1),
       Direction.NorthEast => (1, -1),
       Direction.East => (1, 0),
       Direction.SouthEast => (1, 1),
       Direction.South => (0, 1),
       Direction.SouthWest => (-1, 1),
       Direction.West => (-1, 0),
       Direction.NorthWest => (-1, -1),
        _ => throw new ArgumentOutOfRangeException(nameof(direction)),
    };
}
