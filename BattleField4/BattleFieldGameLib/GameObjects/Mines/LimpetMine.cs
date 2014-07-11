namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;

    public class LimpetMine : Mine
    {
        public LimpetMine()
        {
            this.CreateMine();
            this.Power = MinePower.One;
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
			    { 0, 1, 0, 1, 0 },
			    { 0, 0, 1, 0, 0 },
			    { 0, 1, 0, 1, 0 },
			    { 0, 0, 0, 0, 0 }
            };
        }
    }
}
