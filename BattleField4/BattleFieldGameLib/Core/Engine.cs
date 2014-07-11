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
    /// Facade design pattern for engine
    /// </summary>
    public sealed class Engine
    {
        private static readonly Engine instance = new Engine();

        private const int INITIAL_SCORE = 0;

        private static readonly Random RandomNum = new Random();

        private IDrawer consoleDrawer;
        private IInputable consoleReader;
        private IMineFactory mineFactory;
        private IGameField gameField;
        private IExplosionManager explostionManager;

        private User user;
        private int finalScore;

        // the private fields declared here are always used even though the user may choose not to play
        // the other private fields are generated on demand
        private Engine()
        {
            this.consoleDrawer = new ConsoleRenderer();
            this.consoleReader = new ConsoleInput(this.consoleDrawer);
            this.mineFactory = new MineCreator();
            this.finalScore = INITIAL_SCORE;
        }

        public static Engine GetInstance
        {
            get 
            { 
                return instance;
            }
        }

        public void StartGame()
        {
            // *Intro to the game
            // *Play Music
            // TODO: Menu 
            // TODO: Draw ingame menu (start/stop music)
            GetUserInfo();
            Initialize();
            GameOn();
            GameOver();
        }

        // TODO: Put in gameField
        public bool IsValidPosition()
        {
            if ((0 <= this.user.LastInput.PosX && this.user.LastInput.PosX < this.user.FieldSize) &&
                (0 <= this.user.LastInput.PosY && this.user.LastInput.PosY < this.user.FieldSize))
            {
                return true;
            }

            return false;
        }

        public int PopulateField() // TODO: pass needed arguments to function
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

                this.gameField.FieldBody[x, y] = RandomNum.Next(1, 6).ToString()[0]; // TODO: FIX HACK
            }

            return minesToCreate;
        }

        private void GetUserInfo()
        {
            this.consoleDrawer.DrawText("Enter user name: ");
            this.user = new User(this.consoleReader.GetUsername());
            this.consoleDrawer.DrawText("Enter field size: ");
            this.user.FieldSize = this.consoleReader.GetFieldSize();
        }

        private void Initialize()
        {
            // INITIALIZE GAMEFIELD AND EXPLOSION MANAGER
            this.gameField = new GameField(this.user.FieldSize);
            this.explostionManager = new ExplosionManager(this.gameField); // dependancy injection
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
                    this.user.LastInput = this.consoleReader.GetPositon();
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

        private void GameOver()
        { 
            // TODO: change with highscore logic Use: finalScore
            this.consoleDrawer.DrawText(string.Format("You made it with: {0} tries", this.finalScore));
            // *Save Highscore USE HighScore
            // *Show highscore USE HighScore
        }

        private bool IsMineHit() // TODO: pass needed arguments to function
        {
            char fieldHit = this.gameField[this.user.LastInput.PosX, this.user.LastInput.PosY];

            if (fieldHit == 0 || fieldHit == '*')
            {
                return false;
            }

            return true;
        }

        private void AskForPosition()
        {
            this.consoleDrawer.DrawText("Please enter valid coordinates to hit: ");
        }

        private void ShowLastHit()
        {
            if (this.user.LastInput != null)
            {
                this.consoleDrawer.DrawText(string.Format("Last hit was at: {0} - {1}", this.user.LastInput.PosX, this.user.LastInput.PosY));
            }
        }
    }
}
