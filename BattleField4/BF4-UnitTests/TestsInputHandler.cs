namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    public class FakeReader : IInputable
    {
        public int Fieldsize { get; set; }

        public IPosition Position { get; set; }

        public int MenuChoise { get; set; }

        public string UserName { get; set; }

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

        public IPosition GetPositon()
        {
            return this.Position;
        }

        public string GetUsername()
        {
            return this.UserName;
        }

        public int GetMenuChoice()
        {
            return this.MenuChoise;
        }
    }

    [TestClass]
    public class TestsInputHandler
    {
        // Fieldsize method tests
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

        [TestMethod]
        public void SuccessfulPassAtFieldSizeAbove6OfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            FakeReader reader = new FakeReader();
            reader.Fieldsize = 0;
            var inputHandler = new InputHandler(drawer, reader);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, InputHandler.MinFieldSize + 1);
        }

        [TestMethod]
        public void SuccessfulPassAtFieldSizeBelow40OfGetFieldSize()
        {
            IDrawer drawer = new ConsoleRenderer();
            FakeReader reader = new FakeReader();
            reader.Fieldsize = InputHandler.MaxFieldSize + 10;
            var inputHandler = new InputHandler(drawer, reader);

            var result = inputHandler.GetFieldSize();
            Assert.AreEqual(result, InputHandler.MaxFieldSize - 1);
        }

        // Position method tests
        [TestMethod]
        public void TestingCorrectPositionReturn()
        {
            IDrawer drawer = new ConsoleRenderer();
            FakeReader reader = new FakeReader();
            reader.Position = new Position(5, 5);
            var inputHandler = new InputHandler(drawer, reader);

            var result = inputHandler.GetPositon();
            Assert.IsTrue(result.PosX == 5 && result.PosY == 5);
        }
    }
}