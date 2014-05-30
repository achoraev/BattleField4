namespace Game
{
    using System;

    public struct Position // class or struct .. not sure yet
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
