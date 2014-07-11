namespace BattleFieldGameLib.Common
{
    using BattleFieldGameLib.Interfaces;

    public class Position : IPosition
    {
        public Position(int posX, int posY) 
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public int PosX { get; private set; }

        public int PosY { get; private set; }

    }
}
