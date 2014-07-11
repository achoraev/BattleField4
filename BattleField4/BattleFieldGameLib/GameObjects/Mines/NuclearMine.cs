namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;

    public class NuclearMine : Mine
    {
        public NuclearMine()
        {
            this.CreateMine();
            this.Power = MinePower.Four;
        }

        public override int[,] GetBlastArea()
        {
            return this.MineBody;
        }

        public override void CreateMine()
        {
            this.MineBody = new int[,] 
            {
                { 0, 1, 1, 1, 0 },
			    { 1, 1, 1, 1, 1 },
			    { 1, 1, 1, 1, 1 },
			    { 1, 1, 1, 1, 1 },
			    { 0, 1, 1, 1, 0 }
            };
        }
    }
}
