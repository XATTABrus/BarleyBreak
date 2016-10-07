using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarleyBreak.Library
{
    public class GameWithHistory : GameDecorator
    {
        private readonly Queue<Hashtable> _history;

        public GameWithHistory(AbstractGame game) : base(game)
        {
            _history = new Queue<Hashtable>();
        }

        public override IGame Shift(int value)
        {
            if (!NeighboringCellIsZero(value))
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            var hashtable = new Hashtable();

            var positonZero = GetLocation(0);
            hashtable.Add(0, GetLocation(value));
            hashtable.Add(value, positonZero);
            _history.Enqueue(hashtable);

            return this;
        }

        public override CellPosition GetLocation(int value)
        {
            if (_history.Count != 0)
            {
                foreach (var hashtable in _history.Reverse())
                {
                    if (hashtable.Contains(value))
                        return (CellPosition)hashtable[value];
                }
            }
            return Game.GetLocation(value);
        }

        public override int this[int x, int y]
        {
            get
            {
                var positon = new CellPosition(x, y);

                foreach (var source in _history.Reverse())
                {
                    var key = (from DictionaryEntry e in source where positon.Equals(e.Value) select e.Key).ToArray();

                    if (key.FirstOrDefault() != null)
                        return (int)key.First();
                }
                
                return Game[x, y];
            }
        }
    }
}