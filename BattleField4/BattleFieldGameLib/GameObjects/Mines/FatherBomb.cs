namespace BattleFieldGameLib.GameObjects.Mines
{

    using System;
    using BattleFieldGameLib.Enums;

    public class FatherBomb : Mine
    {
        public FatherBomb()
        {
            this.CreateMine();
            this.Power = MinePower.Five;
        }

        public override int[,] GetBlastArea()
        {
            return this.MineBody;
        }

        public override void CreateMine()
        {
            this.MineBody = new int[,] {{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1}};
        }
    }
}
