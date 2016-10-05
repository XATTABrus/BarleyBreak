using BarleyBreak.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarleyBreak.Tests
{
    [TestClass]
    public class GameWithHistoryTest : BaseGameTest
    {
        protected override IGame GetGame(params int[] args)
        {
            return new GameWithHistory(new ImmutableGame(args));
        }
    }
}
