namespace WordSearch;

internal class Grid(int Width, int Height)
{
    private readonly char[,] grid = new char[Width, Height];

    public char this[int x, int y]
    {
        get => grid[x, y];
        set => grid[x, y] = value;
    }

    public int Width => grid.GetLength(0);

    public int Height => grid.GetLength(1);
}

