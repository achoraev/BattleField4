namespace BattleFieldGameLib.Plugins
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Highscore class. Saves the top 10 players in a files. Uses Singleton and Facade patterns.
    /// </summary>
    public class HighScore : IScorer, ICloneable
    {
        /// <summary>
        /// A collection holding player names and scores.
        /// </summary>
        private Dictionary<string, int> highScoresDictionary;

        /// <summary>
        /// Sorted collection of the players and their score.
        /// </summary>
        private Dictionary<string, int> sortedDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScore" /> class. 
        /// </summary>
        public HighScore()
        {
            this.highScoresDictionary = new Dictionary<string, int>();
            this.sortedDictionary = new Dictionary<string, int>();
        }
      
        /// <summary>
        /// Shows the high score to the UI.
        /// </summary>
        public void ShowHighScore()
        {
            // logic here
        }

        /// <summary>
        /// Saves the high score to a file.
        /// </summary>
        /// <param name="name">Name of the current player.</param>
        /// <param name="score">Score of the current player.</param>
        public void Add(string name, int score)
        {
            this.highScoresDictionary.Add(name, score);

            using (var writer = new StreamWriter("..//highscores.txt", true))
            {
                foreach (var item in this.highScoresDictionary)
                {
                    writer.WriteLine("Name: {0} Score: {1} ", item.Key, item.Value);
                }
            }                   
        }

        // todo if > 10 remove last           

        /// <summary>
        /// Gets the high score from a file.
        /// </summary>
        /// <returns>A collection of player name and score.</returns>
        public IDictionary GetHighScore()
        {
            return this.SortAndPositionHighscores(this.highScoresDictionary);
        }

        /// <summary>
        /// Clones the current high score dictionary (prototype design pattern).
        /// </summary>
        /// <returns>High score results.</returns>
        public object Clone()
        {
            var highScoreResults = new Dictionary<string, int>();

            foreach (var key in this.highScoresDictionary.Keys)
            {
                highScoreResults[key] = this.highScoresDictionary[key];
            }

            return highScoreResults;
        }

        /// <summary>
        /// Sorts the high score collection.
        /// </summary>
        /// <param name="scores">Collection of players names and their score.</param>
        /// <returns>Sorted collection by score.</returns>
        private Dictionary<string, int> SortAndPositionHighscores(Dictionary<string, int> scores)
        {
            scores = scores.OrderByDescending(s => -s.Value).ToDictionary(s => s.Key, s => s.Value);

            return scores;
        }
    }
}