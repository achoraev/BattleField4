namespace BattleFieldGameLib.Core
{
    using System;
    using BattleFieldGameLib.GameObjects.Fields;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Explosion manager class. Gets a position to be hit, checks if mine exists and explode it. Updates the game field.
    /// </summary>
    public class ExplosionHandler : IExplosionHandler
    {
        /// <summary>
        /// Sets the representation of an exploded mine.
        /// </summary>
        private const char DEFAULT_FIELD_BLAST_REPRESENTATION = 'X';

        /// <summary>
        /// Holds an instance of the game field class.
        /// </summary>
        private IGameField gameField;

        /// <summary>
        /// Holds an instance of the current mine.
        /// </summary>
        private IExplodable currentMine;

        /// <summary>
        /// Holds and instance of the current hit position.
        /// </summary>
        private IPosition currentPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplosionHandler" /> class.
        /// </summary>
        /// <param name="gameField">Accepts an instance of the game field.</param>
        public ExplosionHandler(IGameField gameField)
        {
            this.FieldBlastRepresentation = DEFAULT_FIELD_BLAST_REPRESENTATION;
            this.GameField = gameField;
        }

        /// <summary>
        /// Gets or sets the representation of the blasted area.
        /// </summary>
        /// <value>Char representing dead zone.</value>
        public char FieldBlastRepresentation { get; set; }

        /// <summary>
        /// Gets or sets the current mine.
        /// </summary>
        /// <value>IExplodable mine.</value>
        private IExplodable CurrentMine
        {
            get
            {
                return this.currentMine;
            }

            set
            {
                if (value != null)
                {
                    this.currentMine = value;
                }
                else
                {
                    throw new ArgumentNullException("Invalid parameter, null passed as a 'CurrentMine'");
                }
            }
        }

        /// <summary>
        /// Gets or sets the current hit position coordinates.
        /// </summary>
        /// <value>An instance of IPosition.</value>
        private IPosition CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }

            set
            {
                if (value != null)
                {
                    this.currentPosition = value;
                }
                else
                {
                    throw new ArgumentNullException("Invalid parameter, null passed as a 'CurrentPosition'");
                }
            }
        }

        /// <summary>
        /// Gets or sets the game field to be used.
        /// </summary>
        /// <value>An instance of the IGameField.</value>
        private IGameField GameField
        {
            get
            {
                return this.gameField;
            }

            set
            {
                if (value != null)
                {
                    this.gameField = value;
                }
                else
                {
                    throw new ArgumentNullException("Invalid parameter, null passed as a 'GameField'");
                }
            }
        }

        /// <summary>
        /// Sets the position to be hit.
        /// </summary>
        /// <param name="position">Coordinates of the position to be hit.</param>
        public void SetHitPosition(IPosition position)
        {
            this.CurrentPosition = position;
        }

        /// <summary>
        /// Sets the mine that will explode.
        /// </summary>
        /// <param name="mine">An instance of IExplodable.</param>
        public void SetMine(IExplodable mine)
        {
            this.CurrentMine = mine;
        }

        /// <summary>
        /// Walks through every field of the mines' blast area, if there is a mine - takes it out, mark game field as blasted.
        /// </summary>
        /// <returns>The number of mines taken out by the current mine blast area.</returns>
        public int HandleExplosion()
        {
            try
            {
                int fieldLength = this.GameField.FieldBody.GetLength(0) - 1;
                int offsetX = this.CurrentPosition.PosX - 2;
                int offsetY = this.CurrentPosition.PosY - 2;
                int[,] mineBody = this.CurrentMine.GetBlastArea();

                int minesTakenOut = 0;

                // Walks through every field of the mines' blast area
                for (int row = 0; row < mineBody.GetLength(0); row++)
                {
                    for (int col = 0; col < mineBody.GetLength(1); col++)
                    {
                        int rowField = row + offsetX;
                        int colField = col + offsetY;

                        // Don't do anything if you're not in the game field
                        if (rowField < 0 || fieldLength < rowField || colField < 0 || fieldLength < colField)
                        {
                            continue;
                        }

                        // If the blast area covers this field
                        if (mineBody[row, col] == 1)
                        {
                            if (this.IsThereMineIn(rowField, colField))
                            {
                                minesTakenOut++;
                            }

                            this.MarkFieldAsBlasted(rowField, colField);
                        }
                    }
                }

                return minesTakenOut;
            }
            catch (NullReferenceException ex)
            {
                throw new InvalidOperationException("Error. Can't handle explosion", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Error. Can't handle explosion", ex);
            }
        }

        /// <summary>
        /// Marks the blasted area from the current mine to the field.
        /// </summary>
        /// <param name="row">Row to be blasted.</param>
        /// <param name="col">The col of this row to be blasted.</param>
        private void MarkFieldAsBlasted(int row, int col)
        {
            this.GameField[row, col] = this.FieldBlastRepresentation;
        }

        /// <summary>
        /// Checks if there is a mine to the given coordinates.
        /// </summary>
        /// <param name="row">Row to be checked.</param>
        /// <param name="col">Col to be checked.</param>
        /// <returns>Boolean mine or not.</returns>
        private bool IsThereMineIn(int row, int col)
        {
            if ((this.gameField[row, col] != 0) && (this.gameField[row, col] != this.FieldBlastRepresentation))
            {
                return true;
            }

            return false;
        }
    }
}
