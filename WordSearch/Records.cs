using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch;

public record Cell(int X, int Y);

public record SolvedWord(string Word, Cell Start, Direction Direction);
