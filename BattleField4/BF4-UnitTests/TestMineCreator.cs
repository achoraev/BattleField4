namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Core;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class TestMineCreator
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CreateMineShouldReturnProperMines()
        {
            IMineFactory mineCreator = new MineCreator();
            IExplodable lumpetByCreator = mineCreator.CreateMine(MinePower.One);    // Should return 'Lumpet Mine'
            IExplodable nuclearByCreator = mineCreator.CreateMine(MinePower.Four); // Should return 'Nuclear Mine';
            bool isLumpet = lumpetByCreator is LimpetMine;
            bool isNuclear = nuclearByCreator is NuclearMine;
            Assert.IsTrue(isLumpet && isNuclear);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMineWithInvaludPowerShouldThrowExeption() 
        {
            IMineFactory mineCreator = new MineCreator();
            IExplodable lumpetByCreator = mineCreator.CreateMine(new MinePower());    // Hack the mine system
        }
    }
}