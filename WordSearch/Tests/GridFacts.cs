using Xunit;

namespace WordSearch.Tests;

public class GridFacts
{
    private static readonly string[] gridLines =
    [
        "ABCDEF",
        "GHIJKL",
        "MNOPQR",
        "STUVWX",
        "YZABCD",
    ];

    private readonly Grid target = new(gridLines);

    [Fact]
    public void CanCreateGrid() => Assert.NotNull(target);

    [Fact]
    public void DimensionsAreCorrect()
    {
        Assert.Equal(6, target.Width);
        Assert.Equal(5, target.Height);
    }

    [Theory]
    [InlineData(0, 0, 'A')]
    [InlineData(1, 0, 'B')]
    [InlineData(0, 1, 'G')]
    [InlineData(5, 2, 'R')]
    public void CanGetValueAtCoordinate(int x, int y, char value) => Assert.True(target[x, y] == value);

    [Theory]
    [MemberData(nameof(GetKnownWords))]
    public void CanFindWord(string word, Cell cell, Direction direction)
    {
        Assert.True(target.FindWord(word, cell, direction));
    }

    public static IEnumerable<object[]> GetKnownWords()
    {
        yield return new object[] { "ABC", new Cell(0, 0), Direction.East };
        yield return new object[] { "GHI", new Cell(0, 1), Direction.East };
        yield return new object[] { "FLR", new Cell(5, 0), Direction.South };
        yield return new object[] { "DWPIB", new Cell(5, 4), Direction.NorthWest };
    }

    [Fact]
    public void IdentityCloneIsSame()
    {
        var cloned = target.Clone((cell, value) => value);
        Assert.Equal(target.Lines, cloned.Lines);
    }
}
