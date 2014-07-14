namespace BattleFieldGameLib.Renderer
{
    using System;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Main class for drawing to the console. Implements IDrawer interface. Any IDrawer object will work with the program. Strategy.
    /// </summary>
    public class ConsoleRenderer : IDrawer
    {
        /// <summary>
        /// Draws a given object to the console from string.
        /// </summary>
        /// <param name="drawableObject">Accept any instance of IDrawable.</param>
        public void DrawObject(IDrawable drawableObject)
        {
            string objectsToDraw = drawableObject.BitMap();

            for (int i = 0; i < drawableObject.BitMap().Length; i++)
            {
                if (objectsToDraw[i] >= '0' && objectsToDraw[i] <= '9')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (objectsToDraw[i] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(objectsToDraw[i]);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Draws/writes text to the console.
        /// </summary>
        /// <param name="textToDraw">Accepts a string to draw/write.</param>
        public void DrawText(string textToDraw)
        {
            for (int i = 0; i < textToDraw.Length; i++)
            {
                if (textToDraw[i] >= '0')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(textToDraw[i]);
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Clears the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
