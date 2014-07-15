namespace BattleFieldGameLib.Core
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Fields;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using BattleFieldGameLib.Plugins;

    /// <summary>
    /// Facade, Singleton design patterns used for engine. Main game class. Depends on a lot of interfaces documented below.
    /// </summary>
    public sealed class Engine
    {
        /// <summary>
        /// The initial score every new player has.
        /// </summary>
        private const int InitialScore = 0;

        /// <summary>
        /// Singleton pattern. Holds an instance of the engine class.
        /// </summary>
        private static readonly Engine Instance = new Engine();

        /// <summary>
        /// Holds an instance of the random class.
        /// </summary>
        private static readonly Random RandomNum = new Random();

        /// <summary>
        /// Holds an instance of the class that will be used to draw.
        /// </summary>
        private IDrawer consoleDrawer;

        /// <summary>
        /// Holds an instance of the class that will be used to get information from the user.
        /// </summary>
        private IInputable consoleReader;

        /// <summary>
        /// Holds an instance of the class that will be used to handle the information from the user.
        /// </summary>
        private IInputable inputHandler;

        /// <summary>
        /// Holds an instance of the class that will be used to creates mines for the game. Factory pattern.
        /// </summary>
        private IMineFactory mineFactory;

        /// <summary>
        /// Holds an instance of the class that holds the game field.
        /// </summary>
        private IGameField gameField;

        /// <summary>
        /// Holds an instance of the class that will be used to handle explosions of the mines and edit the game field.
        /// </summary>
        private IExplosionHandler explostionManager;

        /// <summary>
        /// Holds an instance of the class that will be used to store user data.
        /// </summary>
        private User user;

        /// <summary>
        /// The final player score.
        /// </summary>
        private int finalScore;

        /// <summary>
        /// Prevents a default instance of the <see cref="Engine" /> class from being created.
        /// </summary>
        private Engine()
        {
            this.consoleDrawer = new ConsoleRenderer();
            this.consoleReader = new ConsoleInput();
            this.inputHandler = new InputHandler(this.consoleDrawer, this.consoleReader);
            this.mineFactory = new MineCreator();
            this.finalScore = InitialScore;
        }

        /// <summary>
        /// Gets the only instance of the Engine class.
        /// </summary>
        /// <value>Engine instance.</value>
        public static Engine GetInstance
        {
            get
            {
                return Instance;
            }
        }

        /// <summary>
        /// Starts the game and the game cycles.
        /// </summary>
        public void StartGame()
        {
            // *Intro to the game
            // *Play Music
            // TODO: Menu 
            // TODO: Draw ingame menu (start/stop music)
            try
            {

                int choice = this.inputHandler.GetMenuChoice();

                if (choice == (int)MenuChoice.Start)
                {
                    this.GetUserInfo();
                    this.Initialize();
                    this.GameOn();
                    this.GameOver();
                }
                else if (choice == (int)MenuChoice.Highscore)
                {
                    //highscore logic
                }
                else if( choice == (int)MenuChoice.Exit)
                {
                    this.GoodBye();
                }
                
            }
            catch (InvalidOperationException ex)
            {
                // TODO: Catch in the invoker, e.g. the Entry class, and print the errors
                throw new InvalidOperationException(string.Format("Error starting the game! {0}"), ex);
            }
        }

        /// <summary>
        /// Displays a short message for the user before ending the game.
        /// </summary>
        private void GoodBye()
        {
            this.consoleDrawer.Clear();
            this.consoleDrawer.DrawText("IF YOU DON'T WANT TO PLAY ... FINE!!!");
        }

        /// <summary>
        /// Gets the user information. Username and Field size.
        /// </summary>
        private void GetUserInfo()
        {
            this.consoleDrawer.Clear();

            this.consoleDrawer.DrawText("Enter user name: ");
            this.user = new User(this.inputHandler.GetUsername());
            this.consoleDrawer.DrawText("Enter field size: ");
            this.user.FieldSize = this.inputHandler.GetFieldSize();
        }

        /// <summary>
        /// Initializes the game field and the explosion handler. If any errors occur an exception will be thrown.
        /// </summary>
        private void Initialize()
        {
            try
            {
                this.gameField = new GameField(this.user.FieldSize);
                this.explostionManager = new ExplosionHandler(this.gameField);
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(string.Format("Can't Initialize 'GameField' and 'ExplosionManager'."), ex);
            }
        }

        /// <summary>
        /// Checks if the position entered by the user is valid and within the field.
        /// </summary>
        /// <returns>Boolean valid or invalid position.</returns>
        private bool IsValidPosition()
        {
            if ((0 <= this.user.LastInput.PosX && this.user.LastInput.PosX < this.user.FieldSize) &&
                (0 <= this.user.LastInput.PosY && this.user.LastInput.PosY < this.user.FieldSize))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The main game cycle.
        /// </summary>
        private void GameOn()
        {
            int minesOnFieldCount = this.PopulateField();

            while (minesOnFieldCount > 0)
            {
                this.consoleDrawer.Clear();
                this.ShowLastHit();
                this.consoleDrawer.DrawObject(this.gameField);

                do
                {
                    this.AskForPosition();
                    this.user.LastInput = this.inputHandler.GetPositon();
                }
                while (!this.IsValidPosition());

                this.finalScore++;

                if (this.IsMineHit())
                {
                    // Generate mine
                    string mineHitOnField = this.gameField[this.user.LastInput.PosX, this.user.LastInput.PosY].ToString();
                    int mineHit = int.Parse(mineHitOnField);
                    var currentMine = this.mineFactory.CreateMine((MinePower)mineHit);

                    // Configure(reconfigure) the explosion manager
                    this.explostionManager.SetMine(currentMine);
                    this.explostionManager.SetHitPosition(this.user.LastInput);

                    // Blow the mine up
                    int minesTakenOut = this.explostionManager.HandleExplosion();

                    minesOnFieldCount -= minesTakenOut;
                }
            }

            this.consoleDrawer.Clear();
            this.ShowLastHit();
            this.consoleDrawer.DrawObject(this.gameField);
        }

        /// <summary>
        /// Populates the game field with mines.
        /// </summary>
        /// <returns>The number of mines that are created.</returns>
        private int PopulateField()
        {
            int fieldSize = this.user.FieldSize;

            int minesToCreate = RandomNum.Next((15 * (fieldSize * fieldSize)) / 100, (30 * (fieldSize * fieldSize)) / (100 + 1));

            for (int i = 0; i < minesToCreate; i++)
            {
                int x = RandomNum.Next(0, fieldSize);
                int y = RandomNum.Next(0, fieldSize);
                while (this.gameField.FieldBody[x, y] != 0)
                {
                    x = RandomNum.Next(0, fieldSize);
                    y = RandomNum.Next(0, fieldSize);
                }

                this.gameField.FieldBody[x, y] = (char)(RandomNum.Next(1, 6) + '0');
            }

            return minesToCreate;
        }

        /// <summary>
        /// Show's the coordinates of the last hit the player has made.
        /// </summary>
        private void ShowLastHit()
        {
            if (this.user.LastInput != null)
            {
                this.consoleDrawer.DrawText(string.Format("Last hit was at: {0} - {1}", this.user.LastInput.PosX, this.user.LastInput.PosY));
            }
            else
            {
                this.consoleDrawer.DrawText(" ");
            }
        }

        /// <summary>
        /// Asks the player for the next hit coordinates.
        /// </summary>
        private void AskForPosition()
        {
            this.consoleDrawer.DrawText("Please enter valid coordinates to hit: ");
        }

        /// <summary>
        /// Checks if on the given coordinates a mine has been hit.
        /// </summary>
        /// <returns>Boolean hit or not.</returns>
        private bool IsMineHit()
        {
            char fieldHit = this.gameField[this.user.LastInput.PosX, this.user.LastInput.PosY];

            if (fieldHit == 0 || fieldHit == this.explostionManager.FieldBlastRepresentation)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method is called when the game is over. Shows the player current score and all time high score.
        /// </summary>
        private void GameOver()
        {
            // TODO: change with highscore logic Use: finalScore
            this.consoleDrawer.DrawText(string.Format("YOU MADE IT WITH: {0} TRIES. CONGRADULATIONS!!!", this.finalScore));

            // TODO: Save Highscore USE HighScore
            // TODO: Show highscore USE HighScore
        }
    }
}
