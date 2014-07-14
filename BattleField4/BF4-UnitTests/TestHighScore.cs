namespace BF4UnitTests
{
    using System;
    using BattleFieldGameLib.Plugins;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    

    [TestClass]
    public class TestHighScore
    {
        [TestMethod]
        public void TestAddHighScore()
        {
            var scoreForAdd = new HighScore("angel", 50);
            Assert.AreEqual(50, scoreForAdd.Score);
            for (int i = 0; i < 10; i++)
            {
                scoreForAdd = new HighScore("angel" + i, i * 50);
                scoreForAdd.AddHighScore();                
            }
            
            Assert.AreEqual(450, scoreForAdd.Score);
        }

        [TestMethod]
        public void TestGetHighScore()
        {
            var scoreForAdd = new HighScore("angel", 50);
            var sortedDictionary = scoreForAdd.GetHighScore("..//highscores.txt");
            Assert.AreEqual(50, scoreForAdd.Score);
            Assert.AreEqual(10, sortedDictionary.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidNamePassedSHouldThrowException()
        {
            var scoreForAdd = new HighScore(null, 50);
        }
    }
}