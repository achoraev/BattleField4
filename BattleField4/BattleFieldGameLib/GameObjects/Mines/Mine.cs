namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.Interfaces;
    
    /// <summary>
    /// Mines base class. All mines inherit this class
    /// </summary>
    public abstract class Mine : IMine, IExplodable
    {
        /// <summary>
        /// Power of the mine.
        /// </summary>
        public MinePower Power { get; set; }

        /// <summary>
        /// The "visualisation" of the current bomb explosion
        /// </summary>
        protected int[,] MineBody { get; set; }

        /// <summary>
        /// Returns mine body. Used method for easy extension or changes in future.
        /// </summary>
        /// <returns>Current mine body integer matrix</returns>
        public abstract int[,] GetBlastArea();

        /// <summary>
        /// Method needed for the mine factory. Creates a mine.
        /// </summary>
        public abstract void CreateMine();
    }
}
