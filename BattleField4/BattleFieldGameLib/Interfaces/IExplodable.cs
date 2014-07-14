namespace BattleFieldGameLib.Interfaces
{
    using System;

    /// <summary>
    /// Interface used by the explosion manager.
    /// </summary>
    public interface IExplodable
    {
        /// <summary>
        /// Gets the blast area/body of the given mine.
        /// </summary>
        /// <returns>Integer matrix.</returns>
        int[,] GetBlastArea();
    }
}
