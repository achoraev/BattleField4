namespace BattleFieldGameLib
{
    using System;

    public class Engine
    {
        private static readonly Random randomNum = new Random();
        private IInputable consoleReader;
        private IDrawer consoleDrawer;
        private User user;
        private IDrawable gameField;

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
            // Populate field matrix USE GameField.Indexer
            // Draw ingame menu (star/stop music)

            while (true)
            {
                Console.Clear();
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

        public bool IsValidPosition()
        {
            if ((0 <= this.user.LastInput.PosX && this.user.LastInput.PosX < this.user.FieldSize) &&
                (0 <= this.user.LastInput.PosY && this.user.LastInput.PosY < this.user.FieldSize))
            {
                return true;
            }

            return false;
        }
    }
}
