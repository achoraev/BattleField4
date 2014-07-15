namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Interface used for the classes that will get the information from the user.
    /// </summary>
    public interface IInputable
    {
        /// <summary>
        /// Asks for the field size that the player wants to play.
        /// </summary>
        /// <returns>Integer for field size.</returns>
        int GetFieldSize();

        /// <summary>
        /// Asks for position to hit.
        /// </summary>
        /// <returns>Instance of IPosition holding the coordinates for the next hit.</returns>
        IPosition GetPositon();

        /// <summary>
        /// Asks for the player's username. Used for high score.
        /// </summary>
        /// <returns>The player's username as string.</returns>
        string GetUsername();

        /// <summary>
        /// Gets the players' menu choice.
        /// </summary>
        /// <returns>Choice made by the player.</returns>
        int GetMenuChoice();
    }
}
