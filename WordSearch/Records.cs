
namespace WordSearch;



public record SolvedWord(string Word, Cell Start, Direction Direction)
{
    public bool ContainsPoint((int x, int y) point)
    {
        // Determine distance between the start point and the given point
        var vector = this.Start.DistanceTo(new Cell(point.x, point.y));

        return vector switch
        {
            _ when vector.IsZero => true,
            _ when vector.Length > Word.Length => false,
            _ when vector.Direction != Direction => false,
            _ => true,
        };
    }
}
