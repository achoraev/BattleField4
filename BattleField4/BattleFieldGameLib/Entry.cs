namespace BattleFieldGameLib
{
    using BattleFieldGameLib.Core;

    public class Entry
    {
        public static void Main()
        {
            var gameEngine = Engine.GetInstance;
            gameEngine.StartGame();
        }
    }
}