using System.Diagnostics;
using System.Text;

namespace WordSearch;

internal class Grid
{
    private readonly char[,] grid;

    public Grid(string[] PuzzleLines)
    {
        this.grid = new char[PuzzleLines[0].Length, PuzzleLines.Length];

        for (int y = 0; y < PuzzleLines.Length; y++)
        {
            for (int x = 0; x < PuzzleLines[y].Length; x++)
            {
                grid[x, y] = PuzzleLines[y][x];
            }
        }
    }

    public char this[int x, int y]
    {
        get => grid[x, y];
        set => grid[x, y] = value;
    }

    public int Width => grid.GetLength(0);

    public int Height => grid.GetLength(1);

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

