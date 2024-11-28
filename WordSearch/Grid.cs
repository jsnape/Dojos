using System.Diagnostics;
using System.Text;

namespace WordSearch;


public class Grid
{
    private readonly char[,] grid;

    public Grid(string[] PuzzleLines)
    {
        this.grid = new char[PuzzleLines.Length, PuzzleLines[0].Length];

        for (int x = 0; x < PuzzleLines.Length; x++)
        {
            for (int y = 0; y < PuzzleLines[x].Length; y++)
            {
                grid[x, y] = PuzzleLines[x][y];
            }
        }
    }

    public char this[int x, int y] => grid[y, x];

    public char this[(int x, int y) point] => grid[point.y, point.x];

    public int Width => grid.GetLength(1);

    public int Height => grid.GetLength(0);

    public bool FindWord(ReadOnlySpan<char> word, (int x, int y) startingPoint, Direction direction)
    {
        Debug.Assert(this[startingPoint] == word[0]);

        var nextPoint = startingPoint;

        for (int i = 1; i < word.Length; i++)
        {
            nextPoint = nextPoint.Move(direction);

            if (this[nextPoint] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                sb.Append(grid[x, y]);
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}

