namespace BattleFieldGameLib.Core
{
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Factory Pattern - Base Class. Implements IMineFactory.
    /// </summary>
    public abstract class MineFactory : IMineFactory
    {
        /// <summary>
        /// Abstract method that the children of this class must use to manufacture mines.
        /// </summary>
        /// <param name="power">Accepts MinePower enumeration to determine the power of the mine.</param>
        /// <returns>Returns an instance of IMine with the given power.</returns>
        public abstract IExplodable CreateMine(MinePower power);
    }
}
