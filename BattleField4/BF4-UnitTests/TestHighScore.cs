namespace BF4UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGameLib.Plugins;
    using BattleFieldGameLib.Interfaces;

    [TestClass]
    public class TestHighScore
    {
        [TestMethod]
        public void TestAddHighScore()
        {
            for (int i = 0; i < 10; i++)
            {
                var scoreForAdd = new HighScore("angel" + i, i * 5);
                //HighScore.AddHighScore();
                // HINT: the test method does nothing
            }

        }

        [TestMethod]
        public void TestGetHighScore()
        {
            // todo check this method
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidNamePassedSHouldThrowException()
        {
            var scoreForAdd = new HighScore(null, 50);
        }
    }
}