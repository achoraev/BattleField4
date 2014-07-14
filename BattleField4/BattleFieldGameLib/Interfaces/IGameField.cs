namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Game field interface. Implements IDrawable, the field will be drawn in any case.
    /// </summary>
    public interface IGameField : IDrawable
    {
        /// <summary>
        /// Gets or sets the body/char matrix of the field.
        /// </summary>
        /// <value>Char matrix.</value>
        char[,] FieldBody { get; set; }

        /// <summary>
        /// Indexer for the field body.
        /// </summary>
        /// <param name="row">Get information at given Row.</param>
        /// <param name="col">Get information at given Col of that row.</param>
        /// <returns>Char symbol.</returns>
        char this[int row, int col]
        {
            get;
            set;
        }
    }
}
