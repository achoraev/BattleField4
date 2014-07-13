namespace BattleFieldGameLib.GameObjects.Fields
{
    using System.Text;
    using BattleFieldGameLib.Interfaces;

    public class GameField : IGameField, IDrawable
    {
        public const int FIELD_SIZE_INCREMENT = 2; // Increases matrix size by 2 for menu items

        public GameField(int fieldSize)
        {
            this.FieldBody = new char[fieldSize, fieldSize];
        }

        public char[,] FieldBody { get; set; }

        public char this[int row, int col]
        {
            get
            {
                return this.FieldBody[row, col];
            }

            set
            {
                this.FieldBody[row, col] = value;
            }
        }

        public string BitMap()
        {
            StringBuilder bodyToDraw = new StringBuilder();
            bodyToDraw.Append("    ");

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.Append(string.Format("{0}", i.ToString().PadRight(3, ' ')));
            }

            bodyToDraw.AppendLine();
            bodyToDraw.Append("    ");
            bodyToDraw.Append(new string('-', this.FieldBody.GetLength(0)* 3));

            bodyToDraw.AppendLine();

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.AppendLine(string.Format("{0}| {1}", i.ToString().PadLeft(2, ' '), this.GetRowInformation(i)));
                bodyToDraw.AppendLine("    " + new string('-', this.FieldBody.GetLength(0)* 3));
            }

            return bodyToDraw.ToString();
        }

        private string GetRowInformation(int rowNumber)
        {
            var result = new StringBuilder();

            for (int col = 0; col < this.FieldBody.GetLength(0); col++)
            {
                result.Append(string.Format("{0}", this.FieldBody[rowNumber, col].ToString().PadRight(2, ' ')));
                result.Append('|');

            }

            return result.ToString();
        }
    }
}
