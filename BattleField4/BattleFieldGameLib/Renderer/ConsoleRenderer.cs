namespace BattleFieldGameLib.Renderer
{
    using System;
    using BattleFieldGameLib.Interfaces;

    public class ConsoleRenderer : IDrawer
    {
        public void DrawObject(IDrawable drawableObject)
        {
            string objectsToDraw = drawableObject.BitMap();

            Console.WriteLine(objectsToDraw);
        }

        public void DrawText(string textToDraw)
        {
            Console.WriteLine(textToDraw);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
