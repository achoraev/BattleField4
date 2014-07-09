namespace BattleFieldGameLib
{
    using System;
    public class ConsoleInput : IInputable
    {
        public int GetFieldSize()
        {
            // FIRST THING WHEN THE GAME STARTS
            var input = Console.ReadLine();
            int fieldSize = 0;
            bool isInteger = int.TryParse(input, out fieldSize);

            while (!isInteger)
            {
                Console.WriteLine("You must enter in integer as field size. Please try again: ");
                GetFieldSize();
            }

            bool isValidSize = (6 < fieldSize && fieldSize < 40);
            while (!isValidSize)
            {
               Console.WriteLine("The field. Please try again: ");
               GetFieldSize(); 
            }

            return fieldSize;
        }

        public IPosition GetPositon()
        {
            // new Position(x,y)

            // Input format - "x y"
            var input = Console.ReadLine();
            var components = input.Split(' ');
            int x, y;
            bool isValidX = int.TryParse(components[0], out x);
            bool isValidY = int.TryParse(components[1], out y);

            //Check if input is inside the field;
            
            while(!isValidX || !isValidY)
	        {
                Console.WriteLine("You have entered an invalid position. Please try again: ");
                GetPositon();
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
