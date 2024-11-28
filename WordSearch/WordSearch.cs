
namespace WordSearch;

public class WordSearch(string[] puzzleLines)
{
    private readonly Grid grid = new(puzzleLines);

    public static string[] Solve(string[] puzzleLines, IEnumerable<string> words)
    {
        var wordSearch = new WordSearch(puzzleLines);
        return wordSearch.Solve(words);
    }

    private string[] Solve(IEnumerable<string> words)
    {
        // For each word, find all the points in the grid with the first letter of the word
        var startingPoints = FindStartingPoints(words);

        // For each found point, check if the remainder of the word exists in any of the 8 directions

    }

    private IEnumerable<(string word, int x, int y)> FindStartingPoints(IEnumerable<string> words)
    {
        foreach (var word in words) 
        {
            var firstLetter = word[0];

            for (var y = 0; y < grid.Height; y++)
            {
                for (var x = 0; x < grid.Width; x++)
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
