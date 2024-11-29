using Xunit;

namespace WordSearch.Tests;

public class WordSearchFacts
{
    private static string[] PuzzleLines =
    [
        "UEWRTRBHCD",
        "CXGZUWRYER",
        "ROCKSBAUCU",
        "SFKFMTYSGE",
        "YSOOUNMZIM",
        "TCGPRTIDAN",
        "HZGHQGWTUV",
        "HQMNDXZBST",
        "NTCLATNBCE",
        "YBURPZUXMS",
    ];

    private static string[] Words = ["RUBY", "DAN", "ROCKS", "MATZ"];

    private readonly WordSearch target = new(PuzzleLines);

    [Fact]
    public void CanFindRubyStartingPoint()
    {
        var actualPoints = target.FindStartingPoints(["RUBY"]).ToArray();

        (string, int, int)[] expectedPoints =
        [
            ("RUBY", 3, 0),
            ("RUBY", 5, 0),
            ("RUBY", 6, 1),
            ("RUBY", 9, 1),
            ("RUBY", 0, 2),
            ("RUBY", 4, 5),
            ("RUBY", 3, 9)
        ];

        foreach (var point in expectedPoints)
        {
            Assert.Contains(point, actualPoints);
        }

        Assert.Equal(expectedPoints.Length, actualPoints.Length);
    }

}
