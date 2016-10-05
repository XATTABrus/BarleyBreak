using System;
using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public abstract class BaseGameTest
    {
        protected abstract IGame GetGame(params int[] args);

        [TestMethod]
        public void CreateGameIsSuccessTest()
        {
            var game1 = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var game2 = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0, 9, 10, 11, 12, 13, 14, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGameIsFailTest()
        {
            var game = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        [TestMethod]
        public void IndexaterTest()
        {
            var game = GetGame(1, 2, 3, 4, 6, 5, 7, 8, 0);

            var result1 = game[1, 1];
            var result2 = game[1, 0];
            var result3 = game[0, 0];

            Assert.AreEqual(6, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(1, result3);
        }

        [TestMethod]
        public void GetLocationTest()
        {
            var game = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var result1 = game.GetLocation(5);
            var result2 = game.GetLocation(0);

            Assert.AreEqual(result1, new CellPosition(1, 1));
            Assert.AreEqual(result2, new CellPosition(2, 2));
        }

        [TestMethod]
        public void ShiftIsSuccessTest()
        {
            var game = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var shift1 = game.Shift(8);
            var shift2 = shift1.Shift(5);
            var shift3 = shift2.Shift(4);
            shift3.Shift(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShiftIsFailTest()
        {
            var game = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            game.Shift(3);
        }
    }
}
