namespace BattleFieldGameLib.Common
{
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// User class. Keeps information about the current player.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class. 
        /// </summary>
        /// <param name="username">The current player username/nickname.</param>
        public User(string username) 
        {
            this.Username = username;
        }

        /// <summary>
        /// Gets or sets the field size that is requested by the user.
        /// </summary>
        /// <value>Integer value.</value>
        public int FieldSize { get; set; }

        /// <summary>
        /// Gets or sets the username of the player.
        /// </summary>
        /// <value>String representing the username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the last position entered by the user.
        /// </summary>
        /// <value>IPosition instance.</value>
        public IPosition LastInput { get; set; }
    }
}
