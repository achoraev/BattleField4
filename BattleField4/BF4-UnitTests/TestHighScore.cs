namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Plugins;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests class HighScore.
    /// </summary>
    [TestClass]
    public class TestHighScore
    {
        /// <summary>
        /// Tests Add method and GetHighScore.
        /// </summary>
        [TestMethod]
        public void TestAddHighScoreAndGetHighScore()
        {
            var scoreForAdd = new HighScore();            
            scoreForAdd.Add("angel", 50);

            Assert.AreEqual(1, scoreForAdd.GetHighScore().Count);
        }

        // [TestMethod]
        // [ExpectedException(typeof(ArgumentNullException))]
        // public void InvalidNamePassedShouldThrowException()
        // {
        //    var scoreForAdd = new HighScore(null, 50);
        // }
    }
}