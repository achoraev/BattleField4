namespace BattleFieldGameLib.Core
{
    using System;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.Renderer;
    using BattleFieldGameLib.UserInput;
    using BattleFieldGameLib.GameObjects.Fields;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.Common;

    /// <summary>
    /// Facade, Singleton design patterns used for engine
    /// </summary>
    public sealed class Engine
    {
        private const int INITIAL_SCORE = 0;
        
        private static readonly Engine Instance = new Engine();
        private static readonly Random RandomNum = new Random();

        private IDrawer consoleDrawer;
        private IInputable consoleReader;
        private IInputable inputHandler;
        private IMineFactory mineFactory;
        private IGameField gameField;
        private IExplosionHandler explostionManager;

        private User user;
        private int finalScore;

        private Engine()
        {
            this.consoleDrawer = new ConsoleRenderer();
            this.consoleReader = new ConsoleInput();
            this.inputHandler = new InputHandler(this.consoleDrawer, this.consoleReader);
            this.mineFactory = new MineCreator();
            this.finalScore = INITIAL_SCORE;
        }

        public static Engine GetInstance
        {
            get 
            { 
                return Instance;
            }
        }

        public void StartGame()
        {
            // *Intro to the game
            // *Play Music
            // TODO: Menu 
            // TODO: Draw ingame menu (start/stop music)
            try
            {
                this.GetUserInfo();
                this.Initialize();
                this.GameOn();
                this.GameOver();
            }
            catch (InvalidOperationException ex)
            {
                // TODO: Catch in the invoker, e.g. the Entry class, and print the errors
                throw new InvalidOperationException(string.Format("Error starting the game! {0}"), ex);
            }
        }

        private void GetUserInfo()
        {
            this.consoleDrawer.DrawText("Enter user name: ");
            this.user = new User(this.inputHandler.GetUsername());
            this.consoleDrawer.DrawText("Enter field size: ");
            this.user.FieldSize = this.inputHandler.GetFieldSize();
        }

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

        private bool IsValidPosition()
        {
            if ((0 <= this.user.LastInput.PosX && this.user.LastInput.PosX < this.user.FieldSize) &&
                (0 <= this.user.LastInput.PosY && this.user.LastInput.PosY < this.user.FieldSize))
            {
                return true;
            }

            return false;
        }

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
                    // generate mine
                    string mineHitOnField = this.gameField[this.user.LastInput.PosX, this.user.LastInput.PosY].ToString();
                    int mineHit = int.Parse(mineHitOnField);
                    var currentMine = this.mineFactory.CreateMine((MinePower)mineHit);

                    // configure(reconfigure) the explosion manager
                    this.explostionManager.SetMine(currentMine);
                    this.explostionManager.SetHitPosition(this.user.LastInput);

                    // blow the mine up
                    int minesTakenOut = this.explostionManager.HandleExplosion();

                    minesOnFieldCount -= minesTakenOut;
                }
            }
        }

        private int PopulateField()
        {
            int fieldSize = this.user.FieldSize;

            int minesToCreate = RandomNum.Next(15 * fieldSize * fieldSize / 100, 30 * fieldSize * fieldSize / 100 + 1);

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
        
        private void ShowLastHit()
        {
            if (this.user.LastInput != null)
            {
                this.consoleDrawer.DrawText(string.Format("Last hit was at: {0} - {1}", this.user.LastInput.PosX, this.user.LastInput.PosY));
            }
        }

        private void AskForPosition()
        {
            this.consoleDrawer.DrawText("Please enter valid coordinates to hit: ");
        }
        
        private bool IsMineHit()
        {
            char fieldHit = this.gameField[this.user.LastInput.PosX, this.user.LastInput.PosY];

            if (fieldHit == 0 || fieldHit == explostionManager.FieldBlastRepresentation)
            {
                return false;
            }

            return true;
        }

        private void GameOver()
        { 
            // TODO: change with highscore logic Use: finalScore
            this.consoleDrawer.DrawText(string.Format("You made it with: {0} tries", this.finalScore));
            // *Save Highscore USE HighScore
            // *Show highscore USE HighScore
        }
    }
}
