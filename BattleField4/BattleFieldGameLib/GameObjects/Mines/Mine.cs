namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.Interfaces;
    
    public abstract class Mine : IMine, IExplodable
    {
        public MinePower Power { get; set; }

        protected int[,] MineBody { get; set; }

        public abstract int[,] GetBlastArea();

        public abstract void CreateMine();
    }
}
