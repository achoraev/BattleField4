namespace BattleFieldGameLib.GameObjects.Fields
{
    using System.Text;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Game Field Class. Holds the information about the game field and mine positions. Implements IGameField, IDrawable.
    /// </summary>
    public class GameField : IGameField, IDrawable
    {
        /// <summary>
        /// Public constant showing the additional fields needed by the game field for drawing headers.
        /// </summary>
        public const int FieldSizeIncrement = 2; // Increases matrix size by 2 for menu items

        /// <summary>
        /// Initializes a new instance of the <see cref="GameField" /> class. 
        /// </summary>
        /// <param name="fieldSize">Field size.</param>
        public GameField(int fieldSize)
        {
            this.FieldBody = new char[fieldSize, fieldSize];
        }

        /// <summary>
        /// Gets or sets field body. Holds game information represented in char matrix.
        /// </summary>
        /// <value>Char Matrix.</value>
        public char[,] FieldBody { get; set; }

        /// <summary>
        /// Gets or sets a given cell in the game field matrix.
        /// </summary>
        /// <param name="row">Row to change.</param>
        /// <param name="col">Column from that row to change.</param>
        /// <returns>Char at the given position.</returns>
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

        /// <summary>
        /// Method that gets the field information, adds additional headers.
        /// </summary>
        /// <returns>String to be passed to the drawer.</returns>
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
            bodyToDraw.Append(new string('-', this.FieldBody.GetLength(0) * 3));

            bodyToDraw.AppendLine();

            for (int i = 0; i < this.FieldBody.GetLength(0); i++)
            {
                bodyToDraw.AppendLine(string.Format("{0}| {1}", i.ToString().PadLeft(2, ' '), this.GetRowInformation(i)));
                bodyToDraw.AppendLine("    " + new string('-', this.FieldBody.GetLength(0) * 3));
            }

            return bodyToDraw.ToString();
        }

        /// <summary>
        /// Gets all columns of a specific row.
        /// </summary>
        /// <param name="rowNumber">Row to get information from.</param>
        /// <returns>Returns hole row information as string.</returns>
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
