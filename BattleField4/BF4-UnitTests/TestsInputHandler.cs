namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// Fake class created for the purpose of testing the InputHandler class.
    /// </summary>
    public class FakeReader : IInputable
    {
        /// <summary>
        /// Holds a test field size value.
        /// </summary>
        public int Fieldsize { get; set; }

        /// <summary>
        /// Holds a test position value.
        /// </summary>
        public IPosition Position { get; set; }

        /// <summary>
        /// Holds a test choise of menu value.
        /// </summary>
        public int MenuChoise { get; set; }

        /// <summary>
        /// Holds a test username value.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets a test value for FieldSize depending on some predetermined conditions.
        /// </summary>
        /// <returns>A test value for the size of the field.</returns>
        public int GetFieldSize()
        {
            var result = this.Fieldsize;
            if (this.Fieldsize <= InputHandler.MinFieldSize)
            {
                this.Fieldsize++;
            }
            else if (this.Fieldsize >= InputHandler.MaxFieldSize)
            {
                this.Fieldsize--;
            }

            return result;
        }

        bool isNullTest = false;

        /// <summary>
        /// Gets a test value for Position depending on some predetermined conditions.
        /// </summary>
        /// <returns>A test value for a position on the field.</returns>
        public IPosition GetPositon()
        {
            var result = this.Position;
            if (!isNullTest && this.Position == null)
            {
                isNullTest = true;
            }

            if (isNullTest)
            {
                result = new Position(1, 1);
            }
            return result;
        }

        /// <summary>
        /// Gets a test value for Username depending on some predetermined conditions.
        /// </summary>
        /// <returns>A test value for username.</returns>
        public string GetUsername()
        {
            return this.UserName;
        }

        /// <summary>
        /// Gets a test value for MenuChoise depending on some predetermined conditions.
        /// </summary>
        /// <returns>A test value for a choise of menu.</returns>
        public int GetMenuChoice()
        {
            return this.MenuChoise;
        }
    }

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
            FakeReader reader = new FakeReader();
            reader.Fieldsize = 8;
            var inputHandler = new InputHandler(drawer, reader);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, 8);
        }

        /// <summary>
        /// Testing GetFieldSize with the smallest allowed value.
        /// </summary>
        [TestMethod]
        public void SuccessfulPassAtFieldSizeAboveMinSizeOfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            FakeReader reader = new FakeReader();
            reader.Fieldsize = 0;
            var inputHandler = new InputHandler(drawer, reader);

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
            FakeReader reader = new FakeReader();
            reader.Fieldsize = InputHandler.MaxFieldSize + 10;
            var inputHandler = new InputHandler(drawer, reader);

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
            FakeReader reader = new FakeReader();
            reader.Position = new Position(5, 5);
            var inputHandler = new InputHandler(drawer, reader);

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
            FakeReader reader = new FakeReader();
            reader.Position = null;
            var inputHandler = new InputHandler(drawer, reader);

            var result = inputHandler.GetPositon();
            Assert.IsTrue(result.PosX == 1 && result.PosY == 1);
        }

        //TODO: MenuCoice Tests
    }
}