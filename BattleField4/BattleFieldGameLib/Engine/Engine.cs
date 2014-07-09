namespace BattleFieldGameLib
{
    using System;

    public class Engine
    {
        private static readonly Random randomNum = new Random();
        private IInputable consoleReader;
        private IDrawer consoleDrawer;
        private User user;
        private GameField gameField;

        public Engine()
        {
            consoleReader = new ConsoleInput();
            consoleDrawer = new ConsoleRenderer();
        }

        public void StartGame()
        {
            // *Intro to the game
            // *Play Music

            user = new User(consoleReader.GetUsername()); // User get Nickname USE ConsoleInput
            user.FieldSize = consoleReader.GetFieldSize(); // User get field size USE ConsoleInput

            // Menu 

            gameField = new GameField(user.FieldSize); // Generate field matrix USE GameField

            // Generate mines USE MineCreator
            PopulateField(); // Populate field matrix USE GameField.Indexer
            // Draw ingame menu (star/stop music)

            while (true)
            {
                consoleDrawer.Clear();
                ShowLastHit();

                consoleDrawer.DrawObject(gameField); // Draw field USE IDrawer.DrawObject

                AskForPosition();
                user.LastInput = consoleReader.GetPositon(); // Ask user for attack position/coordinates USE ConsoleInput

                while (!IsValidPosition())
                {
                    AskForPosition();
                    user.LastInput = consoleReader.GetPositon();
                }

                // Hit {
                // Count destroyed filed/mines USE MineBody
                // Count user score
                // Calculate hit and change the field matrix USE MineBody
                // }
            }

            // Save Highscore USE HighScore
            // Show highscore USE HighScore
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

        // TO DO: Put in gameField
        public bool IsValidPosition()
        {
            if ((0 <= this.user.LastInput.PosX && this.user.LastInput.PosX < this.user.FieldSize) &&
                (0 <= this.user.LastInput.PosY && this.user.LastInput.PosY < this.user.FieldSize))
            {
                return true;
            }

            return false;
        }

        public void PopulateField()
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

                this.gameField.FieldBody[x, y] = randomNum.Next(1, 6).ToString()[0]; // TO DO: FIX HACK
            }
        }
    }
}
