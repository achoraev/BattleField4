namespace BattleFieldGameLib
{
    public class GameField : IDrawable
    {
        public GameField(int fieldSize)
        {
            this.FieldBody = new char[fieldSize, fieldSize];
        }

        public char[,] FieldBody { get; set; }

        public char[,] BitMap()
        {
            return this.FieldBody;
        }

        public char this[int row, int col]
        {
            get { /* return the specified index here */ }
            set { /* set the specified index to value here */ }
        }
    }
}
