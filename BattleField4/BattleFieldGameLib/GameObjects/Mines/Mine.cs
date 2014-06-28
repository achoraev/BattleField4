namespace BattleFieldGameLib
{
    using System;

    public abstract class Mine : IExplodable
    {
        public int[,] BlastArea { get; set; }

        public MinePower Power { get; set; }

        public abstract void Explode();

    }
}
