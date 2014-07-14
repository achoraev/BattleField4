namespace BattleFieldGameLib.Interfaces
{
    using BattleFieldGameLib.Enums;

    /// <summary>
    /// Main factory interface. Implemented by the Factory Pattern.
    /// </summary>
    public interface IMineFactory
    {
        /// <summary>
        /// CreateMine method used by the manufacturers.
        /// </summary>
        /// <param name="power">Enumeration MinePower for creating concrete mine.</param>
        /// <returns>Returns an instance of IMine based on the given mine power.</returns>
        IMine CreateMine(MinePower power);
    }
}
