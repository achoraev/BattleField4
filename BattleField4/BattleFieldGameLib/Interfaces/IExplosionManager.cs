namespace BattleFieldGameLib.Interfaces
{
    public interface IExplosionHandler
    {
        char FieldBlastRepresentation { get; set; }

        void SetHitPosition(IPosition position);

        void SetMine(IExplodable mine);

        int HandleExplosion();
    }
}
