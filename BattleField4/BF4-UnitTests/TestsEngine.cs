namespace BF4_UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleFieldGameLib.Core;

    /// <summary>
    /// Testing methods in Engine class
    /// </summary>
    [TestClass]
    public class TestsEngine
    {
        /// <summary>
        /// Check if only one instance of the Engine class is returned
        /// </summary>
        [TestMethod]
        public void CheckIfOnlyOneInstanceOfEngineIsReturned()
        {
            var engineA = Engine.GetInstance;
            var engineB = Engine.GetInstance;
            Assert.AreSame(engineA, engineB);
        }
    }
}
