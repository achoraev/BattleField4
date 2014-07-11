namespace Game
{
    using System;
    using System.Collections;
	using System.IO;
	using System.IO.StreamWriter;
	using System.IO.StreamReader;
	
    /// <summary>
    /// Singleton + Facade + Strategy
    /// </summary>
    public class HighScore
    {
        private static readonly Highscore highScore = new Highscore();
				
        public string Name { get; private set; }
        public int Points { get; private set; }

        public HighScore(string name, int points) {
            this.Name = name;
            this.Points = points;
        }
		
		// write highScore
		
		// public List<HighScore> highScores = new List<HighScore>();
		// var score = new HighScore() { Name = this.Name, Points = this.Points };
		// highScores.Add(score);

		// using (var writer = new StreamWriter("highscores.txt", false))
		// {
			// writer.highScores;
		// }
		
		// read highScore
		
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
            // logic here
            // if > 10 remove last
        }

        private IDictionary GetHighScore() { 
            // private static List<HighScore> ReadScoresFromFile(String path)
			// {
				var scores = new List<HighScore>();

				using (StreamReader reader = new StreamReader(path)) // path = ...//highscores.txt
				{
					String line;
					while (!reader.EndOfStream)
					{
						line = reader.ReadLine();
						try
						{
							scores.Add(new HighScore(line));
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine("Invalid score at line \"{0}\": {1}", line, ex);
						}
					}
				}

				return SortAndPositionHighscores(scores);
			// }
		
			// sort method
			
			private static List<HighScore> SortAndPositionHighscores(List<HighScore> scores)
			{
				scores = scores.OrderByDescending(s => s.Score).ToList();

				int pos = 1;

				scores.ForEach(s => s.Position = pos++);

				return scores.ToList();
			}
			// open file
            // get lines
            // ad each line to list
            // return the list
        }
    }
}