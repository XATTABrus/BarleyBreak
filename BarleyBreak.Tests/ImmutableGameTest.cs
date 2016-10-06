using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public class ImmutableImmutableGameTest : BaseGameTest
    {
        protected override IGame GetGame(params int[] args)
        {
            return new ImmutableGame(args);
        }

        /// <summary>
        /// Проверка на неизменность объекта, получаем расположение элемента 8 до сдвига и после сдвига у неизменяемого объекта.
        /// </summary>
        [TestMethod]
        public void ImmutabilityTest()
        {
            var game1 = GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var location1 = game1.GetLocation(8);
            var game2 = game1.Shift(8);
            var location2 = game1.GetLocation(8);
            var game3 = game2.Shift(7);
            

            Assert.AreNotEqual(game1, game2);
            Assert.AreNotEqual(game1, game3);
            Assert.AreNotEqual(game2, game3);

            Assert.AreEqual(location1, location2);
        }
    }
}
