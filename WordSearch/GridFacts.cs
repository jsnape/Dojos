using Xunit;

namespace WordSearch;

public class GridFacts
{
    private readonly Grid target = new(2, 3);

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
