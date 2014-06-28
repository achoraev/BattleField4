namespace BattleFieldGameLib
{
    /// <summary>
    /// Factory Pattern - Base Class
    /// </summary>
    public abstract class MineFactory
    {
        public abstract Mine CreateMine(MinePower power);
    }
}
