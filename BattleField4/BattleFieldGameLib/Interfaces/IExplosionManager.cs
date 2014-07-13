namespace BattleFieldGameLib.Interfaces
{
    public interface IExplosionHandler
    {
        void SetHitPosition(IPosition position);

        void SetMine(IExplodable mine);

        int HandleExplosion();

        char FieldBlastRepresentation { get; set; }
    }
}
