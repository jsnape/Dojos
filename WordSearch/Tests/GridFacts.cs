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
    public void CanFindWord(string word, (int x, int y) point, Direction direction)
    {
        Assert.True(target.FindWord(word, point, direction));
    }

    public static IEnumerable<object[]> GetKnownWords()
    {
        yield return new object[] { "ABC", (0, 0), Direction.East };
        yield return new object[] { "GHI", (0, 1), Direction.East };
        yield return new object[] { "FLR", (5, 0), Direction.South };
        yield return new object[] { "DWPIB", (5, 4), Direction.NorthWest };
    }
}
