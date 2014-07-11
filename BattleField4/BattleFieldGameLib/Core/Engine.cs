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
    /// 

    //TODO: make engine with singleton design pattern
    public class Engine
    {
        private const int Initial_Final_Score = 0;

        private static readonly Random randomNum = new Random();

        private IDrawer consoleDrawer;
        private IInputable consoleReader;
        private IMineFactory mineFactory;
        private IGameField gameField;
        private IExplosionManager explostionManager;

        private User user;
        private int finalScore;

        //the private fields declared here are always used even though the user may choose not to play
        //the other private fields are generated on demand
        public Engine()
        {
            consoleDrawer = new ConsoleRenderer();
            consoleReader = new ConsoleInput(consoleDrawer);
            mineFactory = new MineCreator();

            finalScore = Initial_Final_Score;
        }

        public void StartGame()
        {
            // *Intro to the game
            // *Play Music

            //GET USER INFO
            consoleDrawer.DrawText("Enter user name: ");
            user = new User(consoleReader.GetUsername());
            consoleDrawer.DrawText("Enter field size: ");
            user.FieldSize = consoleReader.GetFieldSize();
            
            //TODO: Menu 

            //INITIALIZE GAMEFIELD AND EXPLOSION MANAGER
            gameField = new GameField(user.FieldSize);
            int minesOnFieldCount = PopulateField();
            explostionManager = new ExplosionManager(gameField); //dependancy injection
            
            //TODO: Draw ingame menu (star/stop music)

            while (minesOnFieldCount > 0)
            {
                consoleDrawer.Clear();
                ShowLastHit();//TODO: FIX -> cant easely see what this method needs to do it's work
                consoleDrawer.DrawObject(gameField);

                do
                {
                    AskForPosition();
                    user.LastInput = consoleReader.GetPositon();

                }
                while (!IsValidPosition());//TODO: FIX -> cant easely see what this method needs to do it's work
                finalScore++;

                bool isMineHit = IsMineHit();//TODO: FIX -> cant easely see what this method needs to do it's work

                if (isMineHit)
                {
                    //generate mine
                    string mineHitOnField = gameField[user.LastInput.PosX, user.LastInput.PosY].ToString();
                    int mineHit = int.Parse(mineHitOnField);
                    var currentMine = mineFactory.CreateMine((MinePower)mineHit);

                    //configure(reconfigure) the explosion manager
                    explostionManager.SetMine(currentMine); //strategy
                    explostionManager.SetHitPosition(user.LastInput); //strategy

                    //blow the mine up
                    int minesTakenOut = explostionManager.HandleExplosion();
                    minesOnFieldCount -= minesTakenOut;
                }
            }

            //TODO: change with highscore logic Use: finalScore
            consoleDrawer.DrawText(string.Format("You made it with: {0} tries", finalScore));//this is only a test

            // *Save Highscore USE HighScore
            // *Show highscore USE HighScore
        }

        private bool IsMineHit()//TODO: pass needed arguments to function
        {
            char fieldHit = gameField[user.LastInput.PosX, user.LastInput.PosY];

            if (fieldHit == 0 || fieldHit == '*')
            {
                return false;
            }
            return true;
        }

        private void AskForPosition()
        {
            consoleDrawer.DrawText("Please enter valid coordinates to hit: ");
        }

        private void ShowLastHit()
        {
            if (this.user.LastInput != null)
            {
                consoleDrawer.DrawText(string.Format("Last hit was at: {0} - {1}", this.user.LastInput.PosX, this.user.LastInput.PosY));
            }
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

        public int PopulateField() //TODO: pass needed arguments to function
        {
            int fieldSize = this.user.FieldSize;

            int minesToCreate = randomNum.Next(15 * fieldSize * fieldSize / 100, 30 * fieldSize * fieldSize / 100 + 1);

            for (int i = 0; i < minesToCreate; i++)
            {
                int x = randomNum.Next(0, fieldSize);
                int y = randomNum.Next(0, fieldSize);
                while (this.gameField.FieldBody[x, y] != 0)
                {
                    x = randomNum.Next(0, fieldSize);
                    y = randomNum.Next(0, fieldSize);
                }

                this.gameField.FieldBody[x, y] = randomNum.Next(1, 6).ToString()[0]; // TODO: FIX HACK
            }

            return minesToCreate;
        }
    }
}
