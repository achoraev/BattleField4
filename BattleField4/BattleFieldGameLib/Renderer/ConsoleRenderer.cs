namespace BattleFieldGameLib.Renderer
{
    using System;
    using BattleFieldGameLib.Interfaces;

    public class ConsoleRenderer : IDrawer
    {
        public void DrawObject(IDrawable drawableObject)
        {
            string objectsToDraw = drawableObject.BitMap();

            for (int i = 0; i < objectsToDraw.Length; i++)
            {
                var currentChar = objectsToDraw[i];
                Console.Write(string.Format(" {0}", currentChar));
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void DrawText(string textToDraw)
        {
            Console.WriteLine(textToDraw);
        }
    }
}
