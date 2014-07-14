﻿namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;

    /// <summary>
    /// A mine class. Inherits base class Mine. Using factory pattern for creating the mines.
    /// </summary>
    public class LimpetMine : Mine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimpetMine" /> class.
        /// </summary>
        public LimpetMine()
        {
            this.CreateMine();
            this.Power = MinePower.One;
        }

        /// <summary>
        /// Returns the body of the given mine. Using method for future modifications.
        /// </summary>
        /// <returns>Integer matrix.</returns>
        public override int[,] GetBlastArea()
        {
            return this.MineBody;
        }

        /// <summary>
        /// Sets the mine body.
        /// </summary>
        public override void CreateMine()
        {
            this.MineBody = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0 }
            };
        }
    }
}
