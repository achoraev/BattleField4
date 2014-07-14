namespace BattleFieldGameLib.Common
{
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Position class. Used for representing coordinates in matrix. Implements IPosition.
    /// </summary>
    public class Position : IPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position" /> class.
        /// </summary>
        /// <param name="posX">X or Row coordinate.</param>
        /// <param name="posY">Y or Col coordinate.</param>
        public Position(int posX, int posY) 
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        /// <summary>
        /// Gets the Row/X.
        /// </summary>
        /// <value>Integer value.</value>
        public int PosX { get; private set; }

        /// <summary>
        /// Gets the Col/Y.
        /// </summary>
        /// <value>Integer value.</value>
        public int PosY { get; private set; }
    }
}
