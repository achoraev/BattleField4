namespace Game
{
    using System;

    public abstract class Mine : IExplodable
    {
        public abstract void Explode();

        public abstract Mine CreateMine();
    }
}
