using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarleyBreak.Library
{
    public class ImmutableGame : IGame
    {
        private readonly Hashtable _htKeyPositonCell; // Таблица, ключ которой позиция ячейки
        private readonly Hashtable _htKeyValueCell; // Таблица, ключ которой значение ячейки

        public ImmutableGame(params int[] args)
        {
            if (args.Length < 9)
                throw new ArgumentException("Игра не может состоять меньше чем из 9 элементов!");

            if (!args.ToList().Contains(0))
                throw new ArgumentException("Игра обязательно должна содержать элемент 0!");

            var sizeSide = Math.Sqrt(args.Length);
            // Проверяем что количество элементов образуют квадрат    
            if (sizeSide - Math.Truncate(sizeSide) != 0)
                throw new ArgumentException("Не верное коилчество параметров!");

            _htKeyPositonCell = new Hashtable();
            _htKeyValueCell = new Hashtable();

            var counter = 0;
            // Заполняем хэш-таблицы
            for (var i = 0; i < sizeSide; i++)
                for (var j = 0; j < sizeSide; j++)
                {
                    _htKeyValueCell.Add(args[counter], new CellPosition(i, j));
                    _htKeyPositonCell.Add(new CellPosition(i, j).GetHashCode(), args[counter]);
                    counter++;
                }
        }

        public int this[int x, int y] => (int) _htKeyPositonCell[new CellPosition(x, y).GetHashCode()];

        public CellPosition GetLocation(int value)
        {
            return (CellPosition) _htKeyValueCell[value];
        }

        public IGame Shift(int value)
        {
            var position = (CellPosition) _htKeyValueCell[value];

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

            var zeroPosition = new CellPosition(-1, -1);

            foreach (var neighboringCell in neighboringCells)
            {
                var valueInCall = -1;
                try
                {
                    valueInCall = (int) _htKeyPositonCell[neighboringCell.GetHashCode()];
                }
                catch (Exception)
                {
                    continue;
                }

                if (valueInCall == 0)
                    zeroPosition = neighboringCell;
            }

            if (zeroPosition.X == -1 || zeroPosition.Y == -1)
                throw new InvalidOperationException("Все соседние ячейки не нулевые!");

            // Меняем местами значения ячеек
            _htKeyValueCell[value] = zeroPosition;
            _htKeyValueCell[0] = position;

            _htKeyPositonCell[zeroPosition.GetHashCode()] = value;
            _htKeyPositonCell[position.GetHashCode()] = 0;



            return new ImmutableGame();
        }
    }
}