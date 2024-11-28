using Xunit;

namespace WordSearch;

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

        (string,int,int)[] expectedPoints = 
        [
            ("RUBY", 0, 3),
            ("RUBY", 0, 5),
            ("RUBY", 1, 6),
            ("RUBY", 1, 9),
            ("RUBY", 2, 0),
            ("RUBY", 5, 4),
            ("RUBY", 9, 3)
        ];

        foreach (var point in expectedPoints)
        {
            Assert.Contains(point, actualPoints);
        }

        Assert.Equal(expectedPoints.Length, actualPoints.Length);
    }

}
