namespace BattleFieldGameLib.Interfaces
{
    using BattleFieldGameLib.Common;

    public interface IInputHandler
    {
        /// <summary>
        /// Gets the users' menu choice
        /// </summary>
        /// <returns>Chosen value</returns>
        int GetMenuChoice();

        /// <summary>
        /// Gets the new hit coordinates the user has input
        /// </summary>
        /// <returns></returns>
        IPosition GetPositon();

        /// <summary>
        /// Deals with getting the user input for username and fieldsize
        /// </summary>
        /// <returns>The user data</returns>
        User HandleUserInput();
    }
}
