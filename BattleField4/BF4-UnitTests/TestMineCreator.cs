namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Core;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    

    /// <summary>
    /// Tests Mine creator class.
    /// </summary>
    [TestClass]
    public class TestMineCreator
    {
        /// <summary>
        /// Test Mine creator.
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
        /// Test Father Bomb
        /// </summary>
        [TestMethod]
        public void TestIsFatherBomb()
        {
            IMineFactory mineCreator = new MineCreator();
            IExplodable fatherBomb = mineCreator.CreateMine(MinePower.Five);    // Should return 'Father Bomb'
            bool isFatherBomb = fatherBomb is FatherBomb;
            Assert.IsTrue(isFatherBomb);
        }

        /// <summary>
        /// Test Land Mine
        /// </summary>
        [TestMethod]
        public void TestIsLandMine()
        {
            IMineFactory mineCreator = new MineCreator();
            IExplodable landMine = mineCreator.CreateMine(MinePower.Two);    // Should return 'Land Mine'
            bool isLandMine = landMine is LandMine;
            Assert.IsTrue(isLandMine);
        }

        /// <summary>
        /// Test Navel Mine
        /// </summary>
        [TestMethod]
        public void TestIsNavelMine()
        {
            IMineFactory mineCreator = new MineCreator();
            IExplodable navelMine = mineCreator.CreateMine(MinePower.Three);    // Should return 'Navel Mine'
            bool isNavelMine = navelMine is NavelMine;
            Assert.IsTrue(isNavelMine);
        }

        /// <summary>
        /// Tests exceptions in creating Mines.
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