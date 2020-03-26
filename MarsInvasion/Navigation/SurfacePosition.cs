namespace MarsInvasion.Navigation
{
    public struct SurfacePosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public SurfacePosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
