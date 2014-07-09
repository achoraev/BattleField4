namespace BattleFieldGameLib
{
    using System.Text;

    public class GameField : IDrawable
    {
        public const int FIELD_SIZE_INCREMENT = 2; // Increases matrix size by 2 for menu items

        public GameField(int fieldSize)
        {
            this.FieldBody = new char[fieldSize, fieldSize];
        }

        public char[,] FieldBody { get; set; }

        public string BitMap()
        {
            StringBuilder bodyToDraw = new StringBuilder();
            bodyToDraw.Append(" ");

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.Append(i);
            }

            bodyToDraw.AppendLine();
            bodyToDraw.Append(" ");


            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.Append("-");
            }

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.AppendLine(string.Format("{0}|{1}",i,GetRowInformation(i)));
            }

            return bodyToDraw.ToString();
        }

        public char this[int row, int col]
        {
            get { return this.FieldBody[row, col]; }
            set { this.FieldBody[row, col] = value; }
        }

        private string GetRowInformation(int rowNumber)
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                result.Append(this.FieldBody[rowNumber,i]);
            }

            return result.ToString();
        }
    }
}
