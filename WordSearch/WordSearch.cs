

using System.Diagnostics;
using System.Net.NetworkInformation;

namespace WordSearch;



public class WordSearch(string[] puzzleLines)
{
    private readonly Grid grid = new(puzzleLines);

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
            ((int x, int y) point, char value) => solvedWords.Any(w => w.ContainsPoint(point)) ? value : '+');

        return [];
    }

    public IEnumerable<SolvedWord> FindWords(IEnumerable<string> words)
    {
        // For each word, find all the points in the grid with the first letter of the word
        var startingPoints = FindStartingPoints(words);

        // For each found point, check if the remainder of the word exists in any of the 8 directions
        foreach (var startingPoint in startingPoints)
        {
            var (word, x, y) = startingPoint;

            foreach (int direction in Enum.GetValues(typeof(Direction)))
            {
                if (this.grid.FindWord(word, (x, y), (Direction)direction))
                {
                    yield return new SolvedWord(word, new Cell(x, y), (Direction)direction);
                    break;
                }
            }
        }
    }

    public IEnumerable<(string word, int x, int y)> FindStartingPoints(IEnumerable<string> words)
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
                        yield return (word, x, y);
                    }
                }
            }
        }
    }
}
