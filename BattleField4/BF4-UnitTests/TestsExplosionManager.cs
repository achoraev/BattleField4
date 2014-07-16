namespace BF4_UnitTests
{
    using System;    
    using BattleFieldGameLib.Core;
    using BattleFieldGameLib.GameObjects.Fields;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test ExplosionManager class.
    /// </summary>
    [TestClass]
    public class TestsExplosionManager
    {
        /// <summary>
        /// Test exceptions in ExplosionHandler.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExplosionConstructorShouldThrowExeptionOnNullGameFieldPassedAsArgument()
        {
            var em = new ExplosionHandler(null);
        }

        /// <summary>
        /// Tests exceptions in SetHitPosition.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetHitPositionShouldThrowExeptionOnNullPassed()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
            explosionManager.SetHitPosition(null);
        }

        /// <summary>
        /// Tests exceptions in SetMine.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMineShouldThrowExeptionOnNullPassed()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
            explosionManager.SetMine(null);
        }

        /// <summary>
        /// Tests create field.
        /// </summary>
        [TestMethod]
        public void ExplosionHandlerShouldCreateWithoutErrors()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));
        }

        /// <summary>
        /// Tests exceptions in HandleExplosion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HandleExplosionShouldThrowExeptionOnRunningWithoutMinesCreated()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));

            // No mines added
            explosionManager.HandleExplosion();
        }

        /// <summary>
        /// Test FieldBlastRepresentation == X.
        /// </summary>
        [TestMethod]
        public void CreatingShouldSetTheFiledBlastRepresentationToTheDefaultConstantValue()
        {
            var explosionManager = new ExplosionHandler(new GameField(7));  // The constant is 'X' (private)
            Assert.AreEqual('X', explosionManager.FieldBlastRepresentation);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void HandleExplosionShouldReturnCorrectResultOfDestroyedMines()
        {
            // var explosionManager = new ExplosionHandler(new GameField(7));
            // explosionManager.SetMine(new NuclearMine());

            // explosionManager.SetHitPosition(new Position(3, 3));
            // int result = explosionManager.HandleExplosion();
            // Assert.IsTrue(result == 0);
        }
    }
}