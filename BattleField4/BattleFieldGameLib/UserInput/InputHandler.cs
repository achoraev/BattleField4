namespace BattleFieldGameLib.UserInput
{
    using System;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Common;

    /// <summary>
    /// Main class that will deal with input methods and messages. Implements IInputable interface. Strategy.
    /// </summary>
    public class InputHandler : IInputHandler
    {
        /// <summary>
        /// Sets the default menu choice.
        /// </summary>
        private const int DefaultMenuChoice = 1;

        /// <summary>
        /// Sets the minimum field size.
        /// </summary>
        private const int MinFieldSize = 6;

        /// <summary>
        /// Sets the maximum field size.
        /// </summary>
        private const int MaxFieldSize = 10;

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
        private int GetFieldSize()
        {
            int fieldSize = this.inputer.GetFieldSize();

            while (!(MinFieldSize < fieldSize && fieldSize < MaxFieldSize))
            {
                this.drawer.DrawText("You have entered an invalid field size. Must be between [7, 9] ");
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
                this.drawer.DrawText("You have entered an invalid position. Example: '5 4'");
                position = this.inputer.GetPositon();
            }

            return position;
        }

        /// <summary>
        /// Asks the user for his username. Used for High score.
        /// </summary>
        /// <returns>String player's username.</returns>
        private string GetUsername()
        {
            return this.inputer.GetUsername();
        }

        /// <summary>
        /// Deals with getting the user input for username and fieldsize
        /// </summary>
        /// <returns>The user data</returns>
        public IUser HandleUserInput()
        {
            this.drawer.DrawText("Enter user name: ");
            IUser user = new User(this.GetUsername());
            this.drawer.DrawText("Enter field size: ");
            user.FieldSize = this.GetFieldSize();

            return user;
        }

        /// <summary>
        /// Gets the users' menu choise
        /// </summary>
        /// <returns>Menu choice of the player.</returns>
        private int DrawMainMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    {

                        this.drawer.DrawText("B A T T L E F I E L D  4\n");
                        this.drawer.DrawText("PLAY <<");
                        this.drawer.DrawText("Highscore");
                        this.drawer.DrawText("Exit");
                        break;
                    }
                case 2:
                    {

                        this.drawer.DrawText("B A T T L E F I E L D  4\n");
                        this.drawer.DrawText("PLAY");
                        this.drawer.DrawText("Highscore <<");
                        this.drawer.DrawText("Exit");
                        break;
                    }
                case 3:
                    {

                        this.drawer.DrawText("B A T T L E F I E L D  4\n");
                        this.drawer.DrawText("PLAY");
                        this.drawer.DrawText("Highscore");
                        this.drawer.DrawText("Exit <<");
                        break;
                    }
                default:
                    break;
            }

            return choice;
        }

        /// <summary>
        /// Gets the players' menu choise
        /// </summary>
        /// <returns>Choice made by the player</returns>
        public int GetMenuChoice()
        {
            int currentChoice = DefaultMenuChoice;
            int menuChoice = DefaultMenuChoice;
            bool choiceMade = false;

            while (!choiceMade)
            {
                this.drawer.Clear();

                currentChoice = DrawMainMenuChoice(menuChoice);
                menuChoice = this.inputer.GetMenuChoice();

                if (menuChoice == -1)
                {
                    choiceMade = true;
                }
            }

            return currentChoice;
        }
    }
}
