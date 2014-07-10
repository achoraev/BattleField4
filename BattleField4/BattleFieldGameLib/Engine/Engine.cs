namespace BattleFieldGameLib
{
    using System;
    /// <summary>
    /// Singleton design pattern for engine
    /// </summary>
    /// 

    //TODO: make engine with singleton design pattern
    public class Engine
    {
        private static readonly Random randomNum = new Random();
        private IInputable consoleReader;
        private IDrawer consoleDrawer;
        private User user;
        private GameField gameField;
        private MineFactory mineFactory = new MineCreator();
        private int finalScore = 0;


        //use dependancy injection(design pattern) for private fields in the engine
        //show what the engine class uses in order to work
        public Engine()//TODO: pass needed arguments through the constructor or with dependancy injection
        {
            consoleReader = new ConsoleInput();
            consoleDrawer = new ConsoleRenderer();
        }

        public void StartGame()
        {
            // *Intro to the game
            // *Play Music

            consoleDrawer.DrawText("Enter user name: ");
            user = new User(consoleReader.GetUsername());
            consoleDrawer.DrawText("Enter field size: ");
            user.FieldSize = consoleReader.GetFieldSize();
            user.FieldSize = consoleReader.GetFieldSize(consoleDrawer);

            // Menu 

            gameField = new GameField(user.FieldSize);

            int minesOnFieldCount = PopulateField(); 
            // Draw ingame menu (star/stop music)

            while (minesOnFieldCount > 0)
            {
                consoleDrawer.Clear();
                ShowLastHit();//TODO: FIX -> cant easely see what this method needs to do it's work

                consoleDrawer.DrawObject(gameField);

                AskForPosition();//TODO: FIX -> cant easely see what this method needs to do it's work

                user.LastInput = consoleReader.GetPositon();
                finalScore++; // after user makes a choise finalScore++ (depends on user tries)
                AskForPosition();
                user.LastInput = consoleReader.GetPositon(consoleDrawer);

                while (!IsValidPosition()) //TODO: FIX -> cant easely see what this method needs to do it's work
                {
                    AskForPosition();//TODO: FIX -> cant easely see what this method needs to do it's work
                    user.LastInput = consoleReader.GetPositon();
                    AskForPosition();
                    user.LastInput = consoleReader.GetPositon(consoleDrawer);
                }

                bool isMineHit = IsMineHit();//TODO: FIX -> cant easely see what this method needs to do it's work

                if (isMineHit)
                {
                    //TODO: implement strategy: explosion manager class takes different explosion strategies(mine blasts)
                    //something like: currentMine.Explode(); inside explosion manager
                    //explosionManager(currentMine, gameField);
                    //explosionManager.handleExplosion();
                    int minesTakenOut = Explode();//TODO: FIX -> cant easely see what this method needs to do it's work
                    minesOnFieldCount -= minesTakenOut;
                }
            }

            //TODO: change with highscore logic
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

        private int Explode() //TODO: replace with explode manager (possible to do strategy pattern)
        {
            int mineHit = int.Parse(gameField[user.LastInput.PosX, user.LastInput.PosY].ToString());
            var fieldLength = gameField.FieldBody.GetLength(0) - 1;
            var offsetX = user.LastInput.PosX - 2;
            var offsetY = user.LastInput.PosY - 2;

            //make me a mine and give me it's blast area
            var currentMineBody = mineFactory.CreateMine((MinePower)mineHit).GetBlastArea();

            int minesTakenOut = 0;
            //walks through every field of the mines' blast area
            for (int row = 0; row < currentMineBody.GetLength(0); row++)
            {
                for (int col = 0; col < currentMineBody.GetLength(1); col++)
                {
                    var rowField = row + offsetX;
                    var colField = col + offsetY;

                    //don't do anything if you're not in the game field
                    if (rowField < 0 ||  fieldLength < rowField ||
                        colField < 0 || fieldLength < colField)
                    {
                        continue;
                    }

                    //if the blast area covers this field
                    if (currentMineBody[row, col] == 1)
                    {
                        //if there is a mine ... take it out
                        if ((gameField[rowField, colField] != 0) &&
                            (gameField[rowField, colField] != '*'))
                        {
                            minesTakenOut++;
                        }

                        //mark game field as blasted
                        gameField[rowField, colField] = '*';
                    }
                }
            }

            return minesTakenOut;
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
