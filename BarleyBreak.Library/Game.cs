using System;

namespace BarleyBreak.Library
{
    public class Game : AbstractGame
    {
        public Game(params int[] args) : base (args) {}

        public override IGame Shift(int value)
        {
            if(!NeighboringCellIsZero(value))
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            SwapCellsWithZero(value);
            return this;
        }
    }
}