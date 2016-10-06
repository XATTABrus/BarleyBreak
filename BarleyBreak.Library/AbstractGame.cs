using System;
using System.Collections.Generic;
using System.Linq;

namespace BarleyBreak.Library
{
    public abstract class AbstractGame : IGame
    {
        protected Dictionary<int, int> DictionaryKeyPositonCell; // Таблица, ключ которой позиция ячейки
        protected Dictionary<int, CellPosition> DictionaryKeyValueCell; // Таблица, ключ которой значение ячейки


        protected AbstractGame() { }

        protected AbstractGame(params int[] args)
        {
            CheckArgs(args);

            var sizeSide = (int)Math.Sqrt(args.Length);

            DictionaryKeyPositonCell = new Dictionary<int, int>();
            DictionaryKeyValueCell = new Dictionary<int, CellPosition>();

            var counter = 0;
            // Заполняем хэш-таблицы
            for (var i = 0; i < sizeSide; i++)
                for (var j = 0; j < sizeSide; j++)
                {
                    DictionaryKeyValueCell.Add(args[counter], new CellPosition(i, j));
                    DictionaryKeyPositonCell.Add(new CellPosition(i, j).GetHashCode(), args[counter]);
                    counter++;
                }
        }

        public virtual int this[int x, int y] => DictionaryKeyPositonCell[new CellPosition(x, y).GetHashCode()];

        public virtual CellPosition GetLocation(int value)
        {
            return DictionaryKeyValueCell[value];
        }

        public abstract IGame Shift(int value);

        private void CheckArgs(int[] args)
        {
            if (args.Length < 9)
                throw new ArgumentException("Игра не может состоять меньше чем из 9 элементов!");

            if (!args.ToList().Contains(0))
                throw new ArgumentException("Игра обязательно должна содержать элемент 0!");

            var sizeSide = Math.Sqrt(args.Length);
            if (sizeSide - Math.Truncate(sizeSide) != 0)
                throw new ArgumentException("Не верное коилчество параметров!");
        }

        protected void SwapCellsWithZero(int value)
        {
            var position = DictionaryKeyValueCell[value];
            var zeroPosition = DictionaryKeyValueCell[0];

            // Меняем местами значения ячеек
            DictionaryKeyValueCell[value] = zeroPosition;
            DictionaryKeyValueCell[0] = position;

            DictionaryKeyPositonCell[zeroPosition.GetHashCode()] = value;
            DictionaryKeyPositonCell[position.GetHashCode()] = 0;
        }

        protected bool NeighboringCellIsZero(int value)
        {
            var position = GetLocation(value);

            // Делаем предположение о местонахождение соседних ячеек
            var neighboringCells = new List<CellPosition>
            {
                // Верхняя соседняя ячейка
                new CellPosition(position.X - 1, position.Y),
                // Нижняя соседняя ячейка
                new CellPosition(position.X + 1, position.Y),
                // Правая соседняя ячейка
                new CellPosition(position.X, position.Y + 1),
                // Левая соседняя ячейка
                new CellPosition(position.X, position.Y - 1)
            };

            return neighboringCells.Contains(GetLocation(0));
        }
    }
}