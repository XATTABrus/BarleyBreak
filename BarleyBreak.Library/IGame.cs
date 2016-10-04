namespace BarleyBreak.Library
{
    public interface IGame
    {
        int this[int x, int y] { get; }
        CellPosition GetLocation(int value);
        IGame Shift(int value);
    }
}