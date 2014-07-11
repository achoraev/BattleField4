namespace BattleFieldGameLib.Interfaces
{
    using BattleFieldGameLib.Enums;

    public interface IMineFactory
    {
        IMine CreateMine(MinePower power);
    }
}
