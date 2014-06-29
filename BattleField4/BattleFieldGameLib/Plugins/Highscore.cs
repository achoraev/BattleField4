namespace BattleFieldGameLib
{
    using System;
    using System.Collections;

    /// <summary>
    /// Singleton + Facade
    /// </summary>
    public class Highscore
    {
        private static readonly Highscore Highscore = new Highscore();

        public void ShowHighscore()
        {
            // logic here
        }

        public void AddHighscore(IScorable newScore)
        {
            // logic here
            // if > 10 remove last
        }

        private IDictionary GetHighscore() { 
            // open file
            // get lines
            // ad each line to list
            // return the list
        }
    }
}
