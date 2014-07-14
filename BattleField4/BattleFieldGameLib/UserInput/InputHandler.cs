namespace BattleFieldGameLib.UserInput
{
    using System;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Main class that will deal with input methods and messages. Implements IInputable interface. Strategy.
    /// </summary>
    public class InputHandler : IInputable
    {
        /// <summary>
        /// Sets the minimum field size.
        /// </summary>
        private const int MinFieldSize = 6;

        /// <summary>
        /// Sets the maximum field size.
        /// </summary>
        private const int MaxFieldSize = 40;

        /// <summary>
        /// Holds the instance of the IDrawer interface that is used to write/draw/show the information.
        /// </summary>
        private readonly IDrawer drawer;

        /// <summary>
        /// Holds the instance of the IInputable interface that is used to red/get the information from the user.
        /// </summary>
        private readonly IInputable inputer;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputHandler" /> class. 
        /// </summary>
        /// <param name="drawer">An instance of IDrawer for the UI.</param>
        /// <param name="inputer">An instance of IInputable to get the user input.</param>
        public InputHandler(IDrawer drawer, IInputable inputer)
        {
            this.drawer = drawer;
            this.inputer = inputer;
        }

        /// <summary>
        /// Asks the user for the field size he wants to play.
        /// </summary>
        /// <returns>Integer for the field size.</returns>
        public int GetFieldSize()
        {
            int fieldSize = this.inputer.GetFieldSize();

            while (!(MinFieldSize < fieldSize && fieldSize < MaxFieldSize))
            {
                this.drawer.DrawText("You have entered an invalid field size. Please try again: ");
                fieldSize = this.inputer.GetFieldSize();
            }

            return fieldSize;
        }

        /// <summary>
        /// Asks the user for the next position he wants to hit.
        /// </summary>
        /// <returns>IPosition instance.</returns>
        public IPosition GetPositon()
        {
            var position = this.inputer.GetPositon();
            while (position == null)
            {
                this.drawer.DrawText("You have entered an invalid position. Please try again: ");
                position = this.inputer.GetPositon();
            }

            return position;
        }

        /// <summary>
        /// Asks the user for his username. Used for High score.
        /// </summary>
        /// <returns>String player's username.</returns>
        public string GetUsername()
        {
            return this.inputer.GetUsername();
        }
    }
}
