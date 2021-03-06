﻿namespace BattleFieldGameLib
{
    using System.Diagnostics.CodeAnalysis;
    using BattleFieldGameLib.Core;

    /// <summary>
    /// Entry Point Class. Creates an instance of the engine ant starts the game.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Entry
    {
        /// <summary>
        /// Main program method. Starts the game.
        /// </summary>
        public static void Main()
        {
            var gameEngine = Engine.GetInstance;
            gameEngine.StartGame();
        }
    }
}