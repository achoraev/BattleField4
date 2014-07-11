﻿namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;

    public class LandMine : Mine
    {
        public LandMine()
        {
            this.CreateMine();
            this.Power = MinePower.Two;
        }

        public override int[,] GetBlastArea()
        {
            return this.MineBody;
        }

        public override void CreateMine()
        {
            this.MineBody = new int[,] 
            {
                { 0, 0, 0, 0, 0 },
			    { 0, 1, 1, 1, 0 },
			    { 0, 1, 1, 1, 0 },
			    { 0, 1, 1, 1, 0 },
			    { 0, 0, 0, 0, 0 }
            };
        }
    }
}
