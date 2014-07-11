namespace BattleFieldGameLib.Core
{
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Enums;
    /// <summary>
    /// Factory Pattern - Base Class
    /// </summary>
    public abstract class MineFactory
    {
        public abstract Mine CreateMine(MinePower power);
    }
}
