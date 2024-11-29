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

        (string, Cell)[] expectedPoints =
        [
            ("RUBY", new(3, 0)),
            ("RUBY", new(5, 0)),
            ("RUBY", new(6, 1)),
            ("RUBY", new(9, 1)),
            ("RUBY", new(0, 2)),
            ("RUBY", new(4, 5)),
            ("RUBY", new(3, 9)),
        ];

        foreach (var point in expectedPoints)
        {
            Assert.Contains(point, actualPoints);
        }

        Assert.Equal(expectedPoints.Length, actualPoints.Length);
    }

}
