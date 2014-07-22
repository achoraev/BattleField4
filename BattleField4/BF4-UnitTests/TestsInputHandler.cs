namespace BF4_UnitTests
{
    using System;
    using Moq;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test InputHandler class.
    /// </summary>
    [TestClass]
    public class TestsInputHandler
    {
        //Fieldsize method tests.
        /// <summary>
        /// Testing GetFieldSize method with fieldsize equal to eight.
        /// </summary>

        [TestMethod]
        public void SuccessfulPassAtATrivialCaseOfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            var fakeReader = new Mock<IInputable>();
            fakeReader.Setup(x => x.GetFieldSize()).Returns(8);
            var inputHandler = new InputHandler(drawer, fakeReader.Object);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void SuccessfulPassAtFieldSizeAboveMinSizeOfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            var fakeReader = new Mock<IInputable>();
            var value = 0;
            fakeReader.Setup(x => x.GetFieldSize())
                .Returns(() => value)
                .Callback(() => value++);
            var inputHandler = new InputHandler(drawer, fakeReader.Object);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, InputHandler.MinFieldSize + 1);
        }

        /// <summary>
        /// Testing GetFieldSize with the biggest allowed value.
        /// </summary>
        [TestMethod]
        public void SuccessfulPassAtFieldSizeBelowMaxSizeOfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            var fakeReader = new Mock<IInputable>();
            var value = InputHandler.MaxFieldSize + 10;
            fakeReader.Setup(x => x.GetFieldSize())
                .Returns(() => value)
                .Callback(() => value--);
            var inputHandler = new InputHandler(drawer, fakeReader.Object);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, InputHandler.MaxFieldSize - 1);
        }

        // Position method tests
        /// <summary>
        /// Testing GetPositon with a correct value.
        /// </summary>
        [TestMethod]
        public void TestingCorrectPositionBehaviour()
        {
            IDrawer drawer = new ConsoleRenderer();
            var fakeReader = new Mock<IInputable>();
            fakeReader.Setup(x => x.GetPositon()).Returns(new Position(5, 5));
            var inputHandler = new InputHandler(drawer, fakeReader.Object);

            var result = inputHandler.GetPositon();
            Assert.IsTrue(result.PosX == 5 && result.PosY == 5);
        }

        /// <summary>
        /// Testing GetPositon with a null value.
        /// </summary>
        [TestMethod]
        public void TestingNullPositionBehaviour()
        {
            IDrawer drawer = new ConsoleRenderer();
            var fakeReader = new Mock<IInputable>();
            Position value = null;
            fakeReader.Setup(x => x.GetPositon())
                .Returns(() => value)
                .Callback(() => value = new Position(1, 1));
            var inputHandler = new InputHandler(drawer, fakeReader.Object);

            var result = inputHandler.GetPositon();
            Assert.IsTrue(result.PosX == 1 && result.PosY == 1);
        }

        //TODO: MenuCoice Tests
    }
}