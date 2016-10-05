using System;
using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public class GameWithHistoryTest
    {
        [TestMethod]
        public void CreateGameIsSuccessTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGameIsFailTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 10));
        }

        [TestMethod]
        public void IndexaterTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0));

            var result1 = game[1, 1];
            var result2 = game[1, 0];
            var result3 = game[0, 0];

            Assert.AreEqual(5, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(1, result3);

            game.Shift(8);
            game.Shift(7);

            var result4 = game[2, 2];
            Assert.AreEqual(8, result4);
        }

        [TestMethod]
        public void GetLocationTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0));

            var result1 = game.GetLocation(5);
            var result2 = game.GetLocation(0);

            Assert.AreEqual(result1, new CellPosition(1, 1));
            Assert.AreEqual(result2, new CellPosition(2, 2));
        }

        [TestMethod]
        public void ShiftIsSuccessTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0));

            game.Shift(8);
            game.Shift(5);
            game.Shift(4);
            game.Shift(1);
            game.Shift(1);
            game.Shift(4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShiftIsFailTest()
        {
            var game = new GameWithHistory(new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0));

            game.Shift(8);
            game.Shift(5);
            game.Shift(4);
            game.Shift(1);
            game.Shift(1);
            game.Shift(3);
        }
    }
}
