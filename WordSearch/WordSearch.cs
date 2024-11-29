

using System.Diagnostics;
using System.Net.NetworkInformation;

namespace WordSearch;


public class WordSearch(string[] PuzzleLines)
{
    private readonly Grid grid = new(PuzzleLines);

    public static string[] Solve(string[] puzzleLines, IEnumerable<string> words)
    {
        var wordSearch = new WordSearch(puzzleLines);
        return wordSearch.Solve(words);
    }

    public string[] Solve(IEnumerable<string> words)
    {
        var solvedWords = FindWords(words);

        // Clone the grid but with all cells as '+' not in one of the solved words
        var solvedGrid = grid.Clone(
            (Cell cell, char value) => solvedWords.Any(w => w.ContainsPoint(cell)) ? value : '+');

        return solvedGrid.Lines.ToArray();
    }

    public IEnumerable<SolvedWord> FindWords(IEnumerable<string> words)
    {
        // For each word, find all the points in the grid with the first letter of the word
        var startingPoints = FindStartingPoints(words);

        // For each found point, check if the remainder of the word exists in any of the 8 directions
        foreach (var startingPoint in startingPoints)
        {
            var (word, cell) = startingPoint;

            foreach (int direction in Enum.GetValues(typeof(Direction)))
            {
                if (this.grid.FindWord(word, cell, (Direction)direction))
                {
                    yield return new SolvedWord(word, cell, (Direction)direction);
                    break;
                }
            }
        }
    }

    public IEnumerable<(string word, Cell cell)> FindStartingPoints(IEnumerable<string> words)
    {
        foreach (var word in words) 
        {
            var firstLetter = word[0];

            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    if (grid[x, y] == firstLetter)
                    {
                        yield return (word, new(x, y));
                    }
                }
            }
        }
    }
}
