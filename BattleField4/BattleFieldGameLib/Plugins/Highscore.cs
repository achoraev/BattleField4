namespace BattleFieldGameLib.Plugins
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Singleton + Facade
    /// </summary>
    public class HighScore : IScorable
    {        
        private int score;
        private string name;
        private Dictionary<string, int> highScoresDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> sortedDictionary = new Dictionary<string, int>();
        private int count = 0;

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("Name can't be null value");
                }
            }
        }
      
        public void ShowHighScore()
        {
            // logic here
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddHighScore()
        {
            this.highScoresDictionary.Add(this.name, this.score);

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
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IDictionary GetHighScore(string path)
        {            
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    try
                    {
                        this.sortedDictionary.Add(line, this.count);
                        this.count++;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Invalid score at line \"{0}\": {1}", line, ex);
                    }
                }
            }

            return this.SortAndPositionHighscores(this.sortedDictionary);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        private Dictionary<string, int> SortAndPositionHighscores(Dictionary<string, int> scores) // work with interfaces
        {
            scores = scores.OrderByDescending(s => s.Value).ToDictionary(s => s.Key, s => s.Value);

            return scores;
        }
    }
}