namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// All objects that will be shown/drawn has to implement this interface. 
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// The method that will be used by the drawer to get the string representation of the items to be drawn.
        /// </summary>
        /// <returns>All information as string.</returns>
        string BitMap();
    }
}
