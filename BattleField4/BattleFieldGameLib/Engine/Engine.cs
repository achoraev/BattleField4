namespace BattleFieldGameLib
{
    public class Engine
    {
        // *Intro to the game
        // *Play Music
        // User get Nickname USE ConsoleInput
        // Menu 
        // User get field size USE ConsoleInput
        // Init field
            // Generate field matrix USE GameField
            // Generate mines USE MineCreator
            // Populate field matrix USE GameField.Indexer
        // Draw ingame menu (star/stop music)

        // LOOP { (if remaining mines)
            // Draw field USE IDrawer.DrawObject
            // Ask user for attack position/coordinates USE ConsoleInput
            // Hit {
                // Count destroyed filed/mines USE MineBody
                // Count user score
                // Calculate hit and change the field matrix USE MineBody
                // }
        //}

        // Save Highscore USE HighScore
        // Show highscore USE HighScore
    }
}
