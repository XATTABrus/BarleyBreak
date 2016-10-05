using System;
using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public class ImmutableImmutableGameTest
    {
        [TestMethod]
        public void CreateImmutableGameIsSuccessTest()
        {
            var immutableGame1 = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var immutableGame2 = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0, 9, 10, 11, 12, 13, 14, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateImmutableGameIsFailTest()
        {
            var immutableGame = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        [TestMethod]
        public void IndexaterTest()
        {
            var immutableGame = new ImmutableGame(1, 2, 3, 4, 6, 5, 7, 8, 0);

            var result1 = immutableGame[1, 1];
            var result2 = immutableGame[1, 0];
            var result3 = immutableGame[0, 0];

            Assert.AreEqual(6, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(1, result3);
        }

        [TestMethod]
        public void GetLocationTest()
        {
            var immutableGame = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var result1 = immutableGame.GetLocation(5);
            var result2 = immutableGame.GetLocation(0);

            Assert.AreEqual(result1, new CellPosition(1, 1));
            Assert.AreEqual(result2, new CellPosition(2, 2));
        }

        [TestMethod]
        public void ShiftIsSuccessTest()
        {
            var immutableGame = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var shift1 = immutableGame.Shift(8);
            var shift2 = shift1.Shift(5);
            var shift3 = shift2.Shift(4);
            shift3.Shift(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShiftIsFailTest()
        {
            var immutableGame = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            immutableGame.Shift(3);
        }
    }
}
