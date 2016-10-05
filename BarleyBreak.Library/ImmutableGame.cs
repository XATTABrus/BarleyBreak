using System;
using System.Collections;
using System.Collections.Generic;

namespace BarleyBreak.Library
{
    public class ImmutableGame : AbstractGame
    {
        public ImmutableGame(params int[] args) : base (args) { }

        private ImmutableGame(Hashtable htKeyPositonCell, Hashtable htKeyValueCell)
        {
            HtKeyPositonCell = new Hashtable(htKeyPositonCell);
            HtKeyValueCell = new Hashtable(htKeyValueCell);
        }

        public override IGame Shift(int value)
        {
            if (!NeighboringCellIsZero(value))
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            var gameNew = new ImmutableGame(HtKeyPositonCell, HtKeyValueCell);
            gameNew.SwapCellsWithZero(value);
            return gameNew;
        }
    }
}