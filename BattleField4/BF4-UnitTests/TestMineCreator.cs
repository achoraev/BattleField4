﻿namespace BF4_UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGameLib.Core;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;

    [TestClass]
    public class TestMineCreator
    {
        [TestMethod]
        public void CreateMineShouldReturnProperMines()
        {
            IMineFactory mineCreator = new MineCreator();
            IMine lumpetByCreator = mineCreator.CreateMine(MinePower.One);    // Should return 'Lumpet Mine'
            IMine nuclearByCreator = mineCreator.CreateMine(MinePower.Four); // Should return 'Nuclear Mine';
            bool isLumpet = lumpetByCreator is LimpetMine;
            bool isNuclear = nuclearByCreator is NuclearMine;
            Assert.IsTrue(isLumpet && isNuclear);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMineWithInvaludPowerShouldThrowExeption() 
        {
            IMineFactory mineCreator = new MineCreator();
            IMine lumpetByCreator = mineCreator.CreateMine(new MinePower());    // Hack the mine system
        }
    }
}
