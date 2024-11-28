

using System.Diagnostics;

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
        // For each word, find all the points in the grid with the first letter of the word
        var startingPoints = FindStartingPoints(words);

        // For each found point, check if the remainder of the word exists in any of the 8 directions
        foreach (var startingPoint in startingPoints)
        {
            var (word, x, y) = startingPoint;

            //foreach (var direction in Direction.All)
            //{
            if (this.grid.FindWord(word, (x, y), Direction.East))
            {
                break;
            }
            //}
        }

        return [];
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
