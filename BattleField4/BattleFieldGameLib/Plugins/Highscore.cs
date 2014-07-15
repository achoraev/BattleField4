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
        /// Current count of top players.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScore" /> class. 
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <param name="score">Player score.</param>
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
        /// <param name="path">Accepts the path to the file.</param>
        /// <returns>A collection of player name and score.</returns>
        public IDictionary GetHighScore()//string path)
        {            
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    string line;
            //    while (!reader.EndOfStream)
            //    {
            //        line = reader.ReadLine();
            //        try
            //        {
            //            this.sortedDictionary.Add(line, this.count);
            //            this.count++;
            //        }
            //        catch (ArgumentException ex)
            //        {
            //            Console.WriteLine("Invalid score at line \"{0}\": {1}", line, ex);
            //        }
            //    }
            //}

            //return this.SortAndPositionHighscores(this.sortedDictionary);
            return SortAndPositionHighscores(this.highScoresDictionary);
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

        /// <summary>
        /// Clones the current highscores dictionary (prototype design pattern)
        /// </summary>
        /// <returns>highscrore results</returns>
        public object Clone()
        {
            var highScoreResults = new Dictionary<string, int>();

            foreach (var key in this.highScoresDictionary.Keys)
            {
                highScoreResults[key] = this.highScoresDictionary[key];
            }

            return highScoreResults;
        }
    }
}