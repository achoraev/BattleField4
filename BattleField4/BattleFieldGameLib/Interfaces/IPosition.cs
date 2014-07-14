namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Position/coordinates interface.
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Gets the position X coordinate or Row from matrix.
        /// </summary>
        /// <value>Integer X/Row.</value>
        int PosX { get; }

        /// <summary>
        /// Gets the position Y coordinate or Col from matrix.
        /// </summary>
        /// <value>Integer Y/Col.</value>
        int PosY { get; }
    }
}