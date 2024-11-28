using System;
using Xunit;

namespace WordSearch;

public class WordSearchSpecs
{
    public string[] PuzzleLines =
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

    public string[] Words = ["RUBY", "DAN", "ROCKS", "MATZ"];

    public string[] SolvedLines =
    [
        "+++R++++++",
        "++++U+++++",
        "ROCKSB++++",
        "++++++Y+++",
        "+++++++++M",
        "+++++++DAN",
        "+++++++T++",
        "++++++Z+++",
        "++++++++++",
        "YBUR++++++",
    ];

    [Fact]
    public void CanSolvePuzzle()
    {
        var solved = WordSearch.Solve(PuzzleLines, Words);
        Assert.Equal(SolvedLines, solved);
    }
}
