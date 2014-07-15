namespace BattleFieldGameLib.Interfaces
{
    using System.Collections;
    /// <summary>
    /// IScorable interface. Used for the HighScore calculations.
    /// </summary>
    public interface IScorer
    {
        /// <summary>
        /// Gets the highscores dictionary
        /// </summary>
        /// <returns>Highscores</returns>
        IDictionary GetHighScore();

        /// <summary>
        /// Adds an entry to the highscore
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        void Add(string name, int score);
    }
}
