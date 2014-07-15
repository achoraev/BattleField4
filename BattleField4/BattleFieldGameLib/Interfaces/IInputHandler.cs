namespace BattleFieldGameLib.Interfaces
{
    using BattleFieldGameLib.Common;

    /// <summary>
    /// Input handling interface.
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Gets the users' menu choice.
        /// </summary>
        /// <returns>Chosen value.</returns>
        int GetMenuChoice();

        /// <summary>
        /// Gets the new hit coordinates the user has input.
        /// </summary>
        /// <returns>Instance of IPosition with coordinates given by the user.</returns>
        IPosition GetPositon();

        /// <summary>
        /// Deals with getting the user input for username and field size.
        /// </summary>
        /// <returns>The user data.</returns>
        IUser HandleUserInput();
    }
}
