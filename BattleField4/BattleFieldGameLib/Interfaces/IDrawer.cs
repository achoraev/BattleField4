namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Interface for the drawing/UI class.
    /// </summary>
    public interface IDrawer
    {
        /// <summary>
        /// Accepts the object to be shown/drawn.
        /// </summary>
        /// <param name="drawableObject">IDrawable object.</param>
        void DrawObject(IDrawable drawableObject);

        /// <summary>
        /// Accepts string to be drawn.
        /// </summary>
        /// <param name="text">String to be drawn/shown.</param>
        void DrawText(string text);

        /// <summary>
        /// Clears the interface/console.
        /// </summary>
        void Clear();
    }
}
