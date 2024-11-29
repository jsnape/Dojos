using System;
using Xunit;

namespace WordSearch.Tests;

public class WordSearchSpecs
{
    public readonly static string[] PuzzleLines =
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

    public readonly static string[] Words = ["RUBY", "DAN", "ROCKS", "MATZ"];

    public readonly static string[] SolvedLines =
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
