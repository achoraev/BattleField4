namespace BattleFieldGameLib.UserInput
{
    using System;
    using BattleFieldGameLib.Interfaces;
    public class InputHandler: IInputable
    {
        private const int MinFieldSize = 6;
        private const int MaxFieldSize = 40;

        private readonly IDrawer drawer;
        private readonly IInputable inputer;
        public InputHandler(IDrawer drawer, IInputable inputer)
        {
            this.drawer = drawer;
            this.inputer = inputer;
        }
        public int GetFieldSize()
        {
            int fieldSize = inputer.GetFieldSize();

            while (fieldSize == -1 ||
                !(MinFieldSize < fieldSize && fieldSize < MaxFieldSize))
            {
                this.drawer.DrawText("You have entered an invalid field size. Please try again: ");
                fieldSize = inputer.GetFieldSize(); 
            }

            return fieldSize;
        }

        public IPosition GetPositon()
        {
            var position = inputer.GetPositon();
            while (position == null)
            {
                this.drawer.DrawText("You have entered an invalid position. Please try again: ");
                position = inputer.GetPositon();
            }

            return position;
        }

        public string GetUsername()
        {
            return inputer.GetUsername();
        }
    }
}
