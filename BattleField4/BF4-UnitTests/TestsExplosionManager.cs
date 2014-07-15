namespace BF4_UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGameLib.Core;
    using BattleFieldGameLib.GameObjects.Fields;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Common;

    [TestClass]
    public class TestsExplosionManager
    {
        [TestMethod]
        [ExpectedException (typeof (ArgumentNullException))]
        public void ExplosionConstructorShouldThrowExeptionOnNullGameFieldPassedAsArgument()
        {
            var em = new ExplosionHandler(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetHitPositionShouldThrowExeptionOnNullPassed()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
            explosionManager.SetHitPosition(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMineShouldThrowExeptionOnNullPassed()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
            explosionManager.SetMine(null);
        }

        [TestMethod]
        public void ExplosionHandlerShouldCreateWithoutErrors()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HandleExplosionShouldThrowExeptionOnRunningWithoutMinesCreated()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
            // No mines added
            explosionManager.HandleExplosion();

        }

        [TestMethod]
        public void CreatingShouldSetTheFiledBlastRepresentationToTheDefaultConstantValue()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));  // The constant is 'X' (private)
            Assert.AreEqual('X', explosionManager.FieldBlastRepresentation);
        }

        [TestMethod]
        public void HandleExplosionShouldReturnCorrectResultOfDestroyedMines()
        {
            //var explosionManager = new ExplosionHandler(new GameField(7));
            //explosionManager.SetMine(new NuclearMine());

            //explosionManager.SetHitPosition(new Position(3, 3));
            //int result = explosionManager.HandleExplosion();
            //Assert.IsTrue(result == 0);
        }
    }
}
