namespace BattleFieldGameLib
{
    using System;
    public class ConsoleInput : IInputable
    {
        private const int MinFieldSize = 6;
        private const int MaxFieldSize = 40;

        private static int GetFieldSizeInput()
        {
            var input = Console.ReadLine();
            var result = -1;
            int.TryParse(input, out result);

            return result;
        }

        private static bool GetPositionInput(ref int x, ref int y)
        {
            var input = Console.ReadLine();
            if (input.IndexOf(' ') == -1)
            {
                return false;
            }

            var components = input.Split(' ');
            if (components.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(components[0], out x) || !int.TryParse(components[1], out y))
            {
                return false;
            }

            return true;
        }

        public int GetFieldSize(IDrawer drawer)
        {
            int fieldSize = GetFieldSizeInput();

            while (fieldSize == -1 ||
                !(MinFieldSize < fieldSize && fieldSize < MaxFieldSize))
            {
                drawer.DrawText("You have entered an invalid field size. Please try again: ");
                fieldSize = GetFieldSizeInput();
            }

            return fieldSize;
        }


        public IPosition GetPositon(IDrawer drawer)
        {
            // Required format - "x y"
            int x = -1;
            int y = -1;
            GetPositionInput(ref x, ref y);

            while (x == -1 || y == -1)
            {
                drawer.DrawText("You have entered an invalid position. Please try again: ");
                GetPositionInput(ref x, ref y);
            }

            IPosition position = new Position(x, y);
            return position;
        }

        public string GetUsername()
        {
            var username = Console.ReadLine();

            return username;
        }
    }
}
