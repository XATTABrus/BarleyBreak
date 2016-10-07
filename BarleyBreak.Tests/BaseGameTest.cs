using System;
using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public abstract class BaseGameTest
    {
        protected abstract IGame GetGame(params int[] args);

        private IGame _game;

        [TestInitialize]
        public void TestInitialize()
        {
            _game = GetGame(1, 2, 3, 4, 6, 5, 7, 8, 0);
        }

        /// <summary>
        /// Проверка на корректное создание игрового поля различной площади
        /// </summary>
        [TestMethod]
        public void CreateGameIsSuccessTest()
        {
            GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0, 9, 10, 11, 12, 13, 14, 15);
        }

        /// <summary>
        /// Проверка на создание поля с не верными параметрами
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGameIsFailTest()
        {
            var game = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }
        
        /// <summary>
        /// Проверка работы индексатора
        /// </summary>
        [TestMethod]
        public void IndexaterTest()
        {
            var result1 = _game[1, 1];
            var result2 = _game[1, 0];
            var result3 = _game[0, 0];
            var result4 = _game.Shift(8)[2, 2];

            Assert.AreEqual(6, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(8, result4);

        }

        /// <summary>
        /// Проверка работы метода GetLocation
        /// </summary>
        [TestMethod]
        public void CorrectnessGetLocationAfterGameTest()
        {
            var result1 = _game.GetLocation(5);
            var result2 = _game.GetLocation(0);
            var result3 = _game.Shift(8).GetLocation(0);

            Assert.AreEqual(result1, new CellPosition(1, 1));
            Assert.AreEqual(result2, new CellPosition(2, 2));
            Assert.AreEqual(result3, new CellPosition(2, 1));
        }

        /// <summary>
        /// Проверка работы метода сдвига с корректными значениями
        /// </summary>
        [TestMethod]
        public void ShiftIsSuccessTest()
        {
            var shift1 = _game.Shift(8);
            var shift2 = shift1.Shift(5);
            var shift3 = shift2.Shift(4);
            var shift4 = shift3.Shift(1);
            var shift5 = shift4.Shift(1);

            var locationZero = shift5.GetLocation(0);
            
            Assert.AreEqual(1, locationZero.X);
            Assert.AreEqual(0, locationZero.Y);
        }

        /// <summary>
        /// Проверка работы метода сдвига с не корректными данными
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShiftIsFailTest()
        {
            _game.Shift(3);
        }
    }
}
