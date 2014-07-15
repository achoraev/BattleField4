namespace BattleFieldGameLib.UserInput
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Class that reads information from the console. Implements IInputable. The program will work with any instance of IInputable - Strategy.
    /// </summary>
    public class ConsoleInput : IInputable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInput" /> class. 
        /// </summary>
        public ConsoleInput()
        {
            this.MenuChoice = 1;
        }

        /// <summary>
        /// Gets or sets the menu choice. Holds the choice of the user from the main menu.
        /// </summary>
        /// <value>Integer value for the selected menu.</value>
        public int MenuChoice { get; set; }

        /// <summary>
        /// Gets the field size typed by the user.
        /// </summary>
        /// <returns>Integer containing the filed size to be created.</returns>
        public int GetFieldSize()
        {
            var input = Console.ReadLine();
            var result = -1;
            int.TryParse(input, out result);

            return result;
        }

        /// <summary>
        /// Gets the position to hit. Requires INT INT.
        /// </summary>
        /// <returns>IPosition from the given coordinates.</returns>
        public IPosition GetPositon()
        {
            var input = Console.ReadLine();
            if (input.IndexOf(' ') == -1)
            {
                return null;
            }

            var components = input.Split(' ');
            if (components.Length != 2)
            {
                return null;
            }

            int x = -1;
            int y = -1;

            if (!int.TryParse(components[0], out x) || !int.TryParse(components[1], out y))
            {
                return null;
            }

            var position = new Position(x, y);
            return position;
        }

        /// <summary>
        /// Gets the player username.
        /// </summary>
        /// <returns>String with the users username.</returns>
        public string GetUsername()
        {
            var username = Console.ReadLine();

            return username;
        }

        /// <summary>
        /// Gets the menu choice of the user.
        /// </summary>
        /// <returns>Menu choice the player made.</returns>
        public int GetMenuChoice()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        this.MenuChoice--;
                        break;
                    }
                    else if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        this.MenuChoice++;
                        break;
                    }
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        this.MenuChoice = -1;
                        break;
                    }
                }
            }

            if (this.MenuChoice > 3)
            {
                this.MenuChoice = 1;
            }
            else if (this.MenuChoice < 1)
            {
                if (this.MenuChoice == -1)
                {
                    return this.MenuChoice;
                }

                this.MenuChoice = 3;
            }

            return this.MenuChoice;
        }
    }
}
