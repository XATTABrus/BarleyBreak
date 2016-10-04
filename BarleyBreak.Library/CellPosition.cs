namespace BarleyBreak.Library
{
    public struct CellPosition
    {
        public int X { get; }
        public int Y { get; }

        public CellPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return $"{X}:{Y}".GetHashCode();
        }
    }
}