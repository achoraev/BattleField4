﻿namespace BF4UnitTests
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
                var scoreForAdd = new HighScore("angel"+i, i + 50);
                //HighScore.AddHighScore(scoreForAdd);                
            }                        
        }
    }
}