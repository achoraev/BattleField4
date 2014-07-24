namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.Interfaces;
    
    /// <summary>
    /// Mines base class. All mines inherit this class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class Mine : IExplodable
    {
        /// <summary>
        /// Gets or sets the power of the mine.
        /// </summary>
        /// <value>Enumerable MinePower.</value>
        public MinePower Power { get; set; }

        /// <summary>
        /// Gets or sets the "Visualization" of the current bomb explosion.
        /// </summary>
        /// <value>Integer matrix.</value>
        protected int[,] MineBody { get; set; }

        /// <summary>
        /// Returns mine body. Used method for easy extension or changes in future.
        /// </summary>
        /// <returns>Current mine body integer matrix.</returns>
        public int[,] GetBlastArea()
        {
            if (this.MineBody.GetLength(0) != 5 || this.MineBody.GetLength(1) != 5)
            {
                throw new ArgumentException("Mines have to be int[5, 5] (5x5)");
            }

            return this.MineBody;
        }

        /// <summary>
        /// Method needed for the mine factory. Creates a mine.
        /// </summary>
        public abstract void CreateMine();
    }
}
