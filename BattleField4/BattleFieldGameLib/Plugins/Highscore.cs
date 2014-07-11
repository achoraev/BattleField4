namespace BattleFieldGameLib.Plugins
{
    using System;
    using System.IO;
    using System.Linq;
    using BattleFieldGameLib.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// Singleton + Facade
    /// </summary>
    public class HighScore : IScorable
    {
        //private readonly HighScore highScoreList = new HighScore(name, score);
        private int score;
        private string name;

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = Score; //TODO: fix recursion
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
                this.name = Name; //TODO: fix recursion
            }
        }

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        // using(sr = new StreamReader("highscores.txt")
        // this.label1.Text=sr.ReadLine();For saving the score you can do something like this:

        // StreamReader sr = new StreamReader("highscores.txt");
        // if(Convert.ToInt32(sr.ReadLine())<Convert.ToInt32(this.label1.Text)
        // {
        // sr.Close();
        // using(StreamWriter sw = new StreamWriter("highscores.txt",false))
        // sw.WriteLine(this.label1.Text);
        // }

        public void ShowHighScore()
        {
            // logic here
        }

        public void AddHighScore(IScorable newScore)
        {
            var highScoresList = new List<HighScore>(); //TODO: fix should be outside of method
            var newHighScore = new HighScore(newScore.Name, newScore.Score) //TODO: fix should be outside of method
            {
                Name = this.name, // ?
                Score = this.score // ?
            };

            highScoresList.Add(newHighScore);

            using (var writer = new StreamWriter("../highscores.txt", false))
            {
                writer.WriteLine(newHighScore);
            }
            // logic here
            // if > 10 remove last
        }

        //private IDictionary GetHighScore()
        //{ 
        private static List<HighScore> ReadScoresFromFile(String path) // TODO: FIX: work with interfaces
        {
            var scores = new List<HighScore>(); // TODO: FIX: declaration outside of method

            using (StreamReader reader = new StreamReader(path)) // path = ...//highscores.txt
            {
                String line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    try
                    {
                        scores.Add(new HighScore(line, 100));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Invalid score at line \"{0}\": {1}", line, ex); // throw exception instead of console Write
                    }
                }
            }

            return SortAndPositionHighscores(scores);
        }

        // sort method

        private static List<HighScore> SortAndPositionHighscores(List<HighScore> scores) // work with interfaces
        {
            scores = scores.OrderByDescending(s => s.Name).ToList();

            int pos = 1;

            scores.ForEach(s => s.Score = pos++);

            return scores.ToList();
        }
        // open file
        // get lines
        // ad each line to list
        // return the list
    }
}