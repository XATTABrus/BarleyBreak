using System;

namespace BarleyBreak.Library
{
    public abstract class GameDecorator : AbstractGame
    {
        protected readonly AbstractGame Game;

        protected GameDecorator(AbstractGame game)
        {
            Game = game;
        }

        public override int this[int x, int y] => Game[x, y];

        public override CellPosition GetLocation(int value)
        {
            return Game.GetLocation(value);
        }

        public override IGame Shift(int value)
        {
            return Game.Shift(value);
        }
    }
}