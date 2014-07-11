namespace BattleFieldGameLib
{
    using BattleFieldGameLib;
    using System;

    public class ExplosionManager
    {
        private IExplodable currentMine;
        private IPosition currentPosition;
        private GameField gameField;

        public ExplosionManager(GameField gameField)
        {
            currentMine = null;
            currentPosition = null;
            this.gameField = gameField;

        }

        public void SetHitPosition(IPosition position)
        {
            this.currentPosition = position;
        }

        public void SetMine(IExplodable mine)
        {
            this.currentMine = mine;
        }
        public int HandleExplosion()
        {

            int fieldLength = this.gameField.FieldBody.GetLength(0) - 1;
            int offsetX = this.currentPosition.PosX - 2;
            int offsetY = this.currentPosition.PosY - 2;
            int[,] mineBody = this.currentMine.GetBlastArea();

            int minesTakenOut = 0;
            //walks through every field of the mines' blast area
            for (int row = 0; row < mineBody.GetLength(0); row++)
            {
                for (int col = 0; col < mineBody.GetLength(1); col++)
                {
                    var rowField = row + offsetX;
                    var colField = col + offsetY;

                    //don't do anything if you're not in the game field
                    if (rowField < 0 || fieldLength < rowField ||
                        colField < 0 || fieldLength < colField)
                    {
                        continue;
                    }

                    //if the blast area covers this field
                    if (mineBody[row, col] == 1)
                    {
                        //if there is a mine ... take it out
                        if ((gameField[rowField, colField] != 0) &&
                            (gameField[rowField, colField] != '*'))
                        {
                            minesTakenOut++;
                        }

                        //mark game field as blasted
                        gameField[rowField, colField] = '*';
                    }
                }
            }

            return minesTakenOut;
        }
    }
}
