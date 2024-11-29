using System.Diagnostics;

namespace WordSearch;

[DebuggerDisplay("{Word} {Start} {Direction}")]
public record SolvedWord(string Word, Cell Start, Direction Direction)
{
    public bool ContainsPoint(Cell cell)
    {
        // Determine distance between the start point and the given point
        var vector = this.Start.DistanceTo(cell);

        return vector switch
        {
            _ when vector.IsZero => true,
            _ when vector.Length > Word.Length => false,
            _ when vector.Direction != Direction => false,
            _ => true,
        };
    }

    public IEnumerable<(Cell cell, char value)> Cells
    {
        get
        {
            var current = Start;

            for (int i = 0; i < Word.Length; i++)
            {
                yield return (current, Word[i]);
                current = current.Move(Direction);
            }
        }
    }
}
