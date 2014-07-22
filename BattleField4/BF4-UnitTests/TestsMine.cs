namespace BF4_UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Testing the Mine class
    /// </summary>
    [TestClass]
    public class TestsMine
    {
        /// <summary>
        /// Testing GetBlastArea when input is correct
        /// </summary>
        [TestMethod]
        public void TestingGetBlastAreaCorrectBehavior()
        {
            var newMine = new Mock<IExplodable>();
            newMine.Setup(x => x.GetBlastArea()).Returns(() => new int[5, 5]);

            var result = newMine.Object.GetBlastArea();
            Assert.IsTrue(result.GetLength(0) == 5 && result.GetLength(1) == 5);
        }
    }
}
