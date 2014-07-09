namespace BattleFieldGameLib
{
    using System;
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

        public void DrawText(string textToDraw)
        {
            Console.WriteLine(textToDraw);
        }
    }
}
