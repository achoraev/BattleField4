namespace BattleFieldGameLib.Interfaces
{
    public interface IExplosionManager
    {
        void SetHitPosition(IPosition position);

        void SetMine(IExplodable mine);

        int HandleExplosion();
    }
}
