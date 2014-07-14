namespace BattleFieldGameLib.Core
{
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Factory Pattern - Base Class
    /// </summary>
    public abstract class MineFactory : IMineFactory
    {
        public abstract IMine CreateMine(MinePower power);
    }
}
