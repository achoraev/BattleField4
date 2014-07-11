namespace BattleFieldGameLib
{
    using System;
    using System.Collections;

    /// <summary>
    /// Singleton + Facade
    /// </summary>
    public class Highscore
    {
        private static readonly Highscore highScores = new Highscore();

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
            // open file
            // get lines
            // ad each line to list
            // return the list

            throw new NotImplementedException();
        }
    }
}
