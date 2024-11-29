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

    public char this[Cell cell] => grid[cell.Y, cell.X];

    public int Width => grid.GetLength(1);

    public int Height => grid.GetLength(0);

    public bool FindWord(ReadOnlySpan<char> word, Cell startingPoint, Direction direction)
    {
        Debug.Assert(this[startingPoint] == word[0]);

        var nextPoint = startingPoint;

        for (int i = 1; i < word.Length; i++)
        {
            nextPoint = nextPoint.Move(direction);

            if (!IsInside(nextPoint))
            {
                return false;

            }

            if (this[nextPoint] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    public bool IsInside(Cell cell) => 
        0 <= cell.X && cell.X < Width && 0 <= cell.Y && cell.Y < Height;

    public IEnumerable<string> Lines
    {
        get
        {
            var sb = new StringBuilder(this.Width);

            for (var y = 0; y < Height; ++y)
            {
                for (var x = 0; x < Width; ++x)
                {
                    sb.Append(grid[x, y]);
                }

                yield return sb.ToString();
                sb.Clear();
            }
        }
    }

    public override string ToString() => string.Join(Environment.NewLine, this.Lines);

    public Grid Clone(Func<Cell, char, char> selector)
    {
        var newGrid = new char[Height, Width];

        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                newGrid[y, x] = selector(new Cell(x, y), grid[y, x]);
            }
        }

        return new Grid(newGrid);
    }

    private Grid(char[,] grid) => this.grid = grid;
}

