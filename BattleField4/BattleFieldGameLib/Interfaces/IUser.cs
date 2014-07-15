namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Users interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the player selected field size.
        /// </summary>
        /// <value>Integer for game field size.</value>
        int FieldSize { get; set; }

        /// <summary>
        /// Gets or sets the player username.
        /// </summary>
        /// <value>String for players username.</value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the last position the user chose.
        /// </summary>
        /// <value>IPosition instance holding coordinates for last hit.</value>
        IPosition LastInput { get; set; }
    }
}
