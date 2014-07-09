namespace BattleFieldGameLib
{
    using System;

    public abstract class Mine : IExplodable
    {
        protected int[,] mineBody;

        public MinePower Power { get; set; } 

        public abstract int[,] Explode();

        public abstract void CreateMine();

    }
}
