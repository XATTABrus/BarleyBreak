using System;
using System.Collections;
using System.Collections.Generic;

namespace BarleyBreak.Library
{
    public class ImmutableGame : AbstractGame
    {
        public ImmutableGame(params int[] args) : base (args) { }

        private ImmutableGame(Dictionary<int, int> dictionaryKeyPositonCell, Dictionary<int, CellPosition> dictionaryKeyValueCell)
        {
            DictionaryKeyPositonCell = new Dictionary<int, int>(dictionaryKeyPositonCell);
            DictionaryKeyValueCell = new Dictionary<int, CellPosition>(dictionaryKeyValueCell);
        }

        public override IGame Shift(int value)
        {
            if (!NeighboringCellIsZero(value))
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            var gameNew = new ImmutableGame(DictionaryKeyPositonCell, DictionaryKeyValueCell);
            gameNew.SwapCellsWithZero(value);
            return gameNew;
        }
    }
}