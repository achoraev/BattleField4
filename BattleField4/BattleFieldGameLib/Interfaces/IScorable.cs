namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// IScorable interface. Used for the HighScore calculations.
    /// </summary>
    public interface IScorable
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>String - name of the player.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        /// <value>Score as integer.</value>
        int Score { get; set; }
    }
}
