using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarleyBreak.Library
{
    public class GameWithHistory : GameDecorator
    {
        private readonly Stack<Hashtable> _history;

        public GameWithHistory(AbstractGame game) : base(game)
        {
            _history = new Stack<Hashtable>();
        }

        public override IGame Shift(int value)
        {
            if(!NeighboringCellIsZero(value))
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            var hashtable = _history.Count == 0 ? new Hashtable() : new Hashtable(_history.Peek());          

            var positonZero = GetLocation(0);
            hashtable.Remove(0);
            hashtable.Remove(value);

            hashtable.Add(0, GetLocation(value));
            hashtable.Add(value, positonZero);
            _history.Push(hashtable);

            return this;
        }

        public override CellPosition GetLocation(int value)
        {
            if (_history.Count != 0)
            {
                var lastEdit = _history.Peek();
                if (lastEdit.Contains(value))
                {
                    return (CellPosition) lastEdit[value];
                }
            }
            return Game.GetLocation(value);
        }

        public override int this[int x, int y]
        {
            get
            {
                var positon = new CellPosition(x, y);

                if (_history.Count == 0) return Game[x, y];

                var lastEdit = _history.Peek();
                var key = from DictionaryEntry e in lastEdit where positon.Equals(e.Value) select e.Key;
                return (int)key.FirstOrDefault();
            }
        }
    }
}