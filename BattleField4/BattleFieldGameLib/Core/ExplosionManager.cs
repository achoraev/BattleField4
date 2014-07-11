﻿namespace BattleFieldGameLib.Core
{
    using System;
    using BattleFieldGameLib.Interfaces;
    using BattleFieldGameLib.GameObjects.Fields;

    public class ExplosionManager : IExplosionManager
    {
        private const char defaultFieldBlastRepresentation = '*';

        private IGameField gameField;
        private IExplodable currentMine;
        private IPosition currentPosition;

        public ExplosionManager(IGameField gameField)
        {
            this.FieldBlastRepresentation = defaultFieldBlastRepresentation;
            this.gameField = gameField;
            this.currentMine = null;
            this.currentPosition = null;
        }
        
        public char FieldBlastRepresentation { get; set; }

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

            // walks through every field of the mines' blast area
            for (int row = 0; row < mineBody.GetLength(0); row++)
            {
                for (int col = 0; col < mineBody.GetLength(1); col++)
                {
                    var rowField = row + offsetX;
                    var colField = col + offsetY;

                    // don't do anything if you're not in the game field
                    if (rowField < 0 || fieldLength < rowField ||
                        colField < 0 || fieldLength < colField)
                    {
                        continue;
                    }

                    // if the blast area covers this field
                    if (mineBody[row, col] == 1)
                    {
                        // if there is a mine ... take it out
                        if ((this.gameField[rowField, colField] != 0) &&
                            (this.gameField[rowField, colField] != FieldBlastRepresentation))
                        {
                            minesTakenOut++;
                        }

                        // mark game field as blasted
                        this.gameField[rowField, colField] = FieldBlastRepresentation;
                    }
                }
            }

            return minesTakenOut;
        }
    }
}