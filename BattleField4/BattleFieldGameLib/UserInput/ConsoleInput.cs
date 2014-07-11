namespace BattleFieldGameLib.UserInput
{
    using System;
    using BattleFieldGameLib.Common;
    using BattleFieldGameLib.Interfaces;

    public class ConsoleInput: IInputable
    {
        public int GetFieldSize()
        {
            var input = Console.ReadLine();
            var result = -1;
            int.TryParse(input, out result);

            return result;
        }

        public IPosition GetPositon()
        {
            var input = Console.ReadLine();
            if (input.IndexOf(' ') == -1)
            {
                return null;
            }

            var components = input.Split(' ');
            if (components.Length != 2)
            {
                return null;
            }

            int x = -1;
            int y = -1;

            if (!int.TryParse(components[0], out x) || !int.TryParse(components[1], out y))
            {
                return null;
            }

            var position = new Position(x, y);
            return position;
        }

        public string GetUsername()
        {
            var username = Console.ReadLine();

            return username;
        }
    }
}
