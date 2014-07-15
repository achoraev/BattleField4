namespace BattleFieldGameLib.Interfaces
{
    using System.Collections;

    /// <summary>
    /// IScorable interface. Used for the HighScore calculations.
    /// </summary>
    public interface IScorer
    {
        /// <summary>
        /// Gets the high score dictionary.
        /// </summary>
        /// <returns>High score collection.</returns>
        IDictionary GetHighScore();

        /// <summary>
        /// Adds an entry to the high score.
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <param name="score">Player score for the game.</param>
        void Add(string name, int score);
    }
}
