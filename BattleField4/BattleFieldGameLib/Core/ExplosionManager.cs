namespace BattleFieldGameLib.Core
{
    using System;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.GameObjects.Fields;

    public class ExplosionManager : IExplosionManager
    {
        private const char DEFAULT_FIELD_BLAST_REPRESENTATION = 'X';

        private IGameField gameField;
        private IExplodable currentMine;
        private IPosition currentPosition;

        private IExplodable CurrentMine
        {
            get { return this.currentMine; }
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

        private IPosition CurrentPosition
        {
            get { return this.currentPosition; }
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

        private IGameField GameField
        {
            get { return this.gameField; }
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

        public char FieldBlastRepresentation { get; set; }

        public ExplosionManager(IGameField gameField)
        {
            this.FieldBlastRepresentation = DEFAULT_FIELD_BLAST_REPRESENTATION;
            this.GameField = gameField;
            //this.CurrentMine = null;    // Unnesesery, the null is deafult value
            //this.CurrentPosition = null;    // Unnesesery, the null is deafult value
        }

        public void SetHitPosition(IPosition position)
        {
            this.CurrentPosition = position;
        }

        public void SetMine(IExplodable mine)
        {
            this.CurrentMine = mine;
        }

        /// <summary>
        /// Walks through every field of the mines' blast area, if there is a mine ... take it out, mark game field as blasted
        /// </summary>
        /// <returns>The number of mines taken out by the current mine blast area</returns>
        public int HandleExplosion()    // TODO: Rename this method
        {
            int fieldLength = this.GameField.FieldBody.GetLength(0) - 1;
            int offsetX = this.CurrentPosition.PosX - 2;
            int offsetY = this.CurrentPosition.PosY - 2;
            int[,] mineBody = this.CurrentMine.GetBlastArea();

            int minesTakenOut = 0;

            // walks through every field of the mines' blast area
            for (int row = 0; row < mineBody.GetLength(0); row++)
            {
                for (int col = 0; col < mineBody.GetLength(1); col++)
                {
                    int rowField = row + offsetX;
                    int colField = col + offsetY;

                    // don't do anything if you're not in the game field
                    if (rowField < 0 || fieldLength < rowField || colField < 0 || fieldLength < colField)
                    {
                        continue;
                    }

                    // if the blast area covers this field
                    if (mineBody[row, col] == 1)
                    {
                        // if there is a mine ... take it out
                        if (IsThereMineIn(rowField, colField))
                        {
                            minesTakenOut++;
                        }

                        // mark game field as blasted
                        MarkFieldAsBlasted(rowField, colField);
                    }
                }
            }

            return minesTakenOut;
        }

        private void MarkFieldAsBlasted(int row, int col)
        {
            this.GameField[row, col] = FieldBlastRepresentation;
        }

        private bool IsThereMineIn(int row, int col)
        {
            if ((this.gameField[row, col] != 0) && (this.gameField[row, col] != FieldBlastRepresentation))
            {
                return true;
            }

            return false;
        }
    }
}
