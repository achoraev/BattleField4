namespace BattleFieldGameLib
{

    using System;

    public class FatherBomb : Mine
    {
        public FatherBomb()
        {
            this.CreateMine();
            this.Power = MinePower.Five;
        }

        public override int[,] GetBlastArea()
        {
            return this.mineBody;
        }

        public override void CreateMine()
        {
            this.mineBody = new int[,] {{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1}};
        }
    }
}
