using Xunit;

namespace WordSearch;

public class GridFacts
{
    private static readonly string[] gridLines =
    [
        "AB",
        "CD",
        "EF",
    ];

    private readonly Grid target = new(gridLines);

    [Fact]
    public void CanCreateGrid()
    {
        Assert.NotNull(target);
    }

    [Fact]
    public void DimensionsAreCorrect()
    {
        Assert.Equal(2, target.Width);
        Assert.Equal(3, target.Height);
    }
}
