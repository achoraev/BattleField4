namespace BF4_UnitTests
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// 
    /// </summary>
    public class FakeReader : IInputable
    {
        /// <summary>
        /// 
        /// </summary>
        public int Fieldsize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IPosition Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MenuChoise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IPosition GetPositon()
        {
            return this.Position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUsername()
        {
            return this.UserName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMenuChoice()
        {
            return this.MenuChoise;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class TestsInputHandler
    {        
        // Fieldsize method tests
        /// <summary>
        /// 
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
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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