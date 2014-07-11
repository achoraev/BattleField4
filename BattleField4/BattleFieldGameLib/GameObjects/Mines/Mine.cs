namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Enums;

    public abstract class Mine : IExplodable
    {
        protected int[,] mineBody;

        public MinePower Power { get; set; } 

        public abstract int[,] GetBlastArea();

        public abstract void CreateMine();

    }
}
