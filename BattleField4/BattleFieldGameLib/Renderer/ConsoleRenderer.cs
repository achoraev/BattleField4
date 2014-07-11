namespace BattleFieldGameLib.Renderer
{
    using System;
    using BattleFieldGameLib.Interfaces;

    public class ConsoleRenderer : IDrawer
    {
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

        public void Clear()
        {
            Console.Clear();
        }
    }
}
