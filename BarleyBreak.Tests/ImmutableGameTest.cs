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
    }
}
